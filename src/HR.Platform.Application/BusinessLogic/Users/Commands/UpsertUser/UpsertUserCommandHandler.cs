using HR.Platform.Application.Common.Interfaces;
using HR.Platform.Domain.Entities;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace HR.Platform.Application.BusinessLogic.Users.Commands.UpsertUser
{
    public class UpsertUserCommandHandler : IRequestHandler<UpsertUserCommand, UpsertUserResponseDTO>
    {
        private readonly IHRDbContext _context;

        public UpsertUserCommandHandler(IHRDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<UpsertUserResponseDTO> Handle(UpsertUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.NormalizedEmail == request.Email.ToUpper());

            if (user == null)
            {
                user = new User
                {
                    Email = request.Email,
                    NormalizedEmail = request.Email.ToUpper(),
                    Name = request.Name,
                    ExternalProvider = request.ExternalProvider
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return new UpsertUserResponseDTO
            {
                UserId = user.Id,
                IsActive = user.ApprovedAt.HasValue && !user.DeletedAt.HasValue
            };
        }
    }
}
