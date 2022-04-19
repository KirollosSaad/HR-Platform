using HR.Platform.Application.DIExtensions;
using HR.Platform.Infrastructure.DIExtensions;
using HR.Platform.Application.Constants;
using HR.Platform.Application.Common.Filters;
using HR.Platform.Application.BusinessLogic.Users.Commands.UpsertUser;
using HR.Platform.API.Extensions;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;

using FluentValidation.AspNetCore;
using System.Security.Claims;
using MediatR;

namespace HR.Platform.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabase(Configuration);
            services.AddApplication();

            services.AddCors(options =>
            {
                options.AddPolicy(name: Configurations.CORSPolicy, builder =>
                {
                    builder
                    .WithOrigins(Environment.GetEnvironmentVariable(Configurations.FrontendURL))
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionActionFilter>();
            })
            .AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssembly(typeof(ApplicationDIExtension).Assembly);
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context => context.HandleInvalidRequest();
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = new TimeSpan(48, 0, 0);
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            })
            .AddGoogle(options =>
            {
                options.ClientId = Environment.GetEnvironmentVariable(Configurations.GoogleClientId);
                options.ClientSecret = Environment.GetEnvironmentVariable(Configurations.GoogleClientSecret);
                options.CallbackPath = Environment.GetEnvironmentVariable(Configurations.GoogleCallbackPath);
                options.CorrelationCookie.SecurePolicy = CookieSecurePolicy.Always;
                options.CorrelationCookie.SameSite = SameSiteMode.None;
                options.Events.OnTicketReceived = async context => await HandleTicketReceivedAsync(context);
            })
            .AddJwtBearer();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(Configurations.CORSPolicy);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }

        private async Task HandleTicketReceivedAsync(TicketReceivedContext context)
        {
            var email = context.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var name = context.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            var sender = context.HttpContext.RequestServices.GetRequiredService<ISender>();

            var response = await sender.Send(new UpsertUserCommand
            {
                Email = email,
                Name = name,
                ExternalProvider = GoogleDefaults.AuthenticationScheme
            });

            if (response.IsActive)
            {
                var claimsIdentity = (ClaimsIdentity)context.Principal.Identity;
                var existingIdentityClaim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (existingIdentityClaim != null)
                {
                    claimsIdentity.TryRemoveClaim(existingIdentityClaim);
                }

                claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, response.UserId));
            }
            else
            {
                context.Response.Redirect($"{Environment.GetEnvironmentVariable(Configurations.FrontendURL)}/login");
                context.HandleResponse();
            }
        }
    }
}
