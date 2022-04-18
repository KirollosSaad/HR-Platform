using MediatR;

namespace HR.Platform.Application.BusinessLogic.Users.Commands.UpsertUser
{
    public class UpsertUserCommand : IRequest<UpsertUserResponseDTO>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ExternalProvider { get; set; }
    }
}
