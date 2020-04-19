using FestivalWebApp.API.Models;
using FluentValidation;

namespace FestivalWebApp.API.Validators
{
    public class FestivalUpdateValidator: AbstractValidator<FestivalUpdateRequestBody>
    {
        private const int FestivalNameMaxSize = 50;
        private const int FestivalDescriptionMaxSize = 200;
        
        public FestivalUpdateValidator()
        {
            RuleFor(f => f.Name).MaximumLength(FestivalNameMaxSize);
            RuleFor(f => f.Description).MaximumLength(FestivalDescriptionMaxSize);
        }
    }
}