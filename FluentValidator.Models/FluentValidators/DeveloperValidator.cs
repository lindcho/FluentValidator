using System;
using FluentValidation;

namespace FluentValidator.Models.FluentValidators
{
    public class DeveloperValidator : AbstractValidator<Developer>
    {
        public DeveloperValidator()
        {
            RuleFor(p => p.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure) // scenarios where you actually need not run multiple validation rules for a property even if it fails at the first rule.
                                                         // means that when the validator hits it’s first error for the corresponding property, it stops
                .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
                .Length(2, 25)
                .Must(CustomValidation.IsValidName).WithMessage("{PropertyName} should be all letters.");

            RuleFor(p => p.LastName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
                .Length(2, 25)
                .Must(CustomValidation.IsValidName).WithMessage("{PropertyName} should be all letters.");

            // JUST FOR CONTROL
            RuleFor(p => p.LastName).NotEqual(p=>p.FirstName, StringComparer.Ordinal);

            RuleFor(p => p.Email)
                .EmailAddress();

            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(x => x.DateOfBirth)
                .Must(CustomValidation.AgeValidate)
                .WithMessage("Invalid {PropertyName}. Age must be 21 or greater than 21");
        }
    }
}