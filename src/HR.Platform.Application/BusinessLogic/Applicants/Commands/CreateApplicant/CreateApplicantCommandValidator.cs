using FluentValidation;
using HR.Platform.Application.Constants;

namespace HR.Platform.Application.BusinessLogic.Applicants.Commands.CreateApplicant
{
    public class CreateApplicantCommandValidator : AbstractValidator<CreateApplicantCommand>
    {
        public CreateApplicantCommandValidator()
        {
            RuleFor(x => x.Name)
            .MaximumLength(FieldLength.MediumLength)
            .NotEmpty();

            RuleFor(x => x.Email)
            .MaximumLength(FieldLength.SmallLength)
            .NotEmpty();


            RuleFor(x => x.Phone)
            .MaximumLength(FieldLength.VerySmallLength)
            .NotEmpty();

            RuleFor(x => x.Summary)
            .MaximumLength(FieldLength.LargeLength);

            RuleFor(x => x.CreatedBy)
            .MaximumLength(FieldLength.SmallLength)
            .NotEmpty();
        }
    }
}
