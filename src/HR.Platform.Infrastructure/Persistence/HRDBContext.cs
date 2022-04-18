using HR.Platform.Application.Common.Interfaces;
using HR.Platform.Domain.Entities;
using HR.Platform.Domain.Entities.Interfaces;

using HR.Platform.Infrastructure.Persistence.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Internal;

using System.Reflection;

namespace HR.Platform.Infrastructure.Persistence
{
    public class HRDBContext : DbContext, IHRDbContext
    {
        private readonly ISystemClock _systemClock;

        public HRDBContext(ISystemClock systemClock, DbContextOptions<HRDBContext> options) : base(options)
        {
            _systemClock = systemClock ?? throw new ArgumentNullException(nameof(systemClock));
        }

        public DbSet<Applicant> Applicants => Set<Applicant>();
        public DbSet<User> Users => Set<User>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = _systemClock.UtcNow.DateTime;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = _systemClock.UtcNow.DateTime;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(IAuditableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                }
            }

            base.OnModelCreating(builder);
        }
    }
}
