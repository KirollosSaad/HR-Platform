using HR.Platform.Application.Common.Interfaces;
using HR.Platform.Domain.Entities;

using MediatR;

namespace HR.Platform.Application.BusinessLogic.Applicants.Commands.CreateApplicant
{
    public class CreateApplicantCommandHandler : IRequestHandler<CreateApplicantCommand, string>
    {
        private readonly IHRDbContext _context;

        public CreateApplicantCommandHandler(IHRDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<string> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = new Applicant
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Summary = request.Summary,
                CreatedById = request.CreatedBy,
            };

            await _context.Applicants.AddAsync(applicant);
            await _context.SaveChangesAsync(cancellationToken);
            return applicant.Id;
        }
    }
}
