using HR.Platform.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace HR.Platform.Application.Common.Interfaces
{
    public interface IHRDbContext
    {
        DbSet<Applicant> Applicants { get; }
        DbSet<User> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
