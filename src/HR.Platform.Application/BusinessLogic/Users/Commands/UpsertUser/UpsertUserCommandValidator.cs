using FluentValidation;

using HR.Platform.Application.Constants;

namespace HR.Platform.Application.BusinessLogic.Users.Commands.UpsertUser
{
    public class UpsertUserCommandValidator : AbstractValidator<UpsertUserCommand>
    {
        public UpsertUserCommandValidator()
        {
            RuleFor(x => x.Name)
            .MaximumLength(FieldLength.MediumLength)
            .NotEmpty();

            RuleFor(x => x.Email)
            .MaximumLength(FieldLength.SmallLength)
            .NotEmpty();

            RuleFor(x => x.ExternalProvider)
            .MaximumLength(FieldLength.SmallLength);
        }
    }
}
