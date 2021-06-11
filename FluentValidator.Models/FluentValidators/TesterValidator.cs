using FluentValidation;

namespace FluentValidator.Models.FluentValidators
{
    public class TesterValidator : AbstractValidator<Tester>
    {
        public TesterValidator()
        {
            RuleFor(p => p.FirstName)
                .Cascade(CascadeMode.Stop) // scenarios where you actually need not run multiple validation rules for a property even if it fails at the first rule.
                // means that when the validator hits it’s first error for the corresponding property, it stops
                .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
                .Length(2, 25);

        }
    }
}