using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HR.Platform.Application.Common.Filters
{
    public class ExceptionActionFilter : ExceptionFilterAttribute
    {
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly ILogger<ExceptionActionFilter> _logger;

        public ExceptionActionFilter(IHostEnvironment hostingEnvironment, ILogger<ExceptionActionFilter> log)
        {
            _logger = log ?? throw new ArgumentNullException(nameof(log));
            _hostingEnvironment = hostingEnvironment;
        }

        public override void OnException(ExceptionContext context)
        {
            var actionDescriptor = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
            var controllerType = actionDescriptor.ControllerTypeInfo;
            var controllerName = context.RouteData.Values["controller"]?.ToString();
            var actionName = context.RouteData.Values["action"]?.ToString();

            var controllerBase = typeof(ControllerBase);
            var statusCode = GetStatusCode(context.Exception);

            _logger.LogError("{ControllerName}/{ActionName}/{Exception}/{StatusCode}", controllerName, actionName, context.Exception.GetType().Name, statusCode);
            _logger.LogError($"URL: {GetAbsoluteUrl(context)}\n{context.Exception.Message}\n{context.Exception.StackTrace}");

            if (controllerType.IsSubclassOf(controllerBase))
            {
                context.HttpContext.Response.StatusCode = statusCode;
            }
            else
            {
                context.HttpContext.Response.StatusCode = statusCode;
                if (_hostingEnvironment.EnvironmentName.ToLower() == "production")
                {
                    context.Result = new RedirectResult($"/home/error/{statusCode}");
                }
            }

            context.ExceptionHandled = true;
            base.OnException(context);
        }

        private int GetStatusCode(Exception exception)
        {
            if (typeof(ArgumentException) == exception.GetType())
            {
                return (int)System.Net.HttpStatusCode.BadRequest;
            }

            if (typeof(ArgumentNullException) == exception.GetType())
            {
                return (int)System.Net.HttpStatusCode.BadRequest;
            }

            if (typeof(FormatException) == exception.GetType())
            {
                return (int)System.Net.HttpStatusCode.BadRequest;
            }

            if (typeof(FormatException) == exception.GetType())
            {
                return (int)System.Net.HttpStatusCode.BadRequest;
            }

            if (typeof(NotImplementedException) == exception.GetType())
            {
                return (int)System.Net.HttpStatusCode.NotImplemented;
            }

            if (typeof(AccessViolationException) == exception.GetType())
            {
                return (int)System.Net.HttpStatusCode.Unauthorized;
            }

            if (typeof(UnauthorizedAccessException) == exception.GetType())
            {
                return (int)System.Net.HttpStatusCode.Unauthorized;
            }

            if (typeof(NullReferenceException) == exception.GetType())
            {
                return (int)System.Net.HttpStatusCode.InternalServerError;
            }

            return (int)System.Net.HttpStatusCode.InternalServerError;
        }

        private string GetAbsoluteUrl(ExceptionContext context)
        {
            var request = context.HttpContext.Request;
            var absoluteUrl = string.Concat(
                        request.Scheme,
                        "://",
                        request.Host.ToUriComponent(),
                        request.PathBase.ToUriComponent(),
                        request.Path.ToUriComponent(),
                        request.QueryString.ToUriComponent());
            return absoluteUrl;
        }
    }

}
