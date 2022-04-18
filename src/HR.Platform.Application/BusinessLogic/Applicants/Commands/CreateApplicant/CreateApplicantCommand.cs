using MediatR;

namespace HR.Platform.Application.BusinessLogic.Applicants.Commands.CreateApplicant
{
    public class CreateApplicantCommand : IRequest<string>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Summary { get; set; }
        public string? CreatedBy { get; set; }
    }
}
