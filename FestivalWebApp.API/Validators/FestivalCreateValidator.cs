using FestivalWebApp.API.Models;
using FluentValidation;

namespace FestivalWebApp.API.Validators
{
    public class FestivalCreateValidator : AbstractValidator<FestivalCreateRequestBody>
    {
        private const int FestivalNameMaxSize = 50;
        private const int FestivalDescriptionMaxSize = 200;

        public FestivalCreateValidator()
        {
            RuleFor(f => f.Name).MaximumLength(FestivalNameMaxSize);
            RuleFor(f => f.Description).MaximumLength(FestivalDescriptionMaxSize);
        }
    }
}