using FestivalWebApp.API.Models;
using FluentValidation;

namespace FestivalWebApp.API.Validators
{
    public class ParticipantUpdateValidator : AbstractValidator<ParticipantUpdateRequestBody>
    {
        private const int NameMaxSize = 50;
        private const int SecondNameMaxSize = 50;
        private const string ErrorMessage = "Id must be greater than 0.";

        public ParticipantUpdateValidator()
        {
            RuleFor(p => p.FestivalId).GreaterThan(0).WithMessage(ErrorMessage);
            RuleFor(p => p.Name).MaximumLength(NameMaxSize);
            RuleFor(p => p.SecondName).MaximumLength(SecondNameMaxSize);
        }
    }
}