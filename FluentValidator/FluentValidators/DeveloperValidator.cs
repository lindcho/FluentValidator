using System;
using System.Linq;
using FluentValidation;
using FluentValidator.Models;

namespace FluentValidator.FluentValidators
{
    public class DeveloperValidator : AbstractValidator<Developer>
    {
        //{ POSTMAN
        //    "FirstName": "980120",
        //    "LastName": "NDABA",
        //    "Email": "lindo1@ymail.com",
        //     "DateOfBirth": "1998-05-05",
        //    "Experience": 5
        //}

        public DeveloperValidator()
        {
            RuleFor(p => p.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure) // scenarios where you actually need not run multiple validation rules for a property even if it fails at the first rule.
                                                         // means that when the validator hits it’s first error for the corresponding property, it stops
                .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
                .Length(2, 25)
                .Must(IsValidName).WithMessage("{PropertyName} should be all letters.");

            RuleFor(p => p.LastName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
                .Length(2, 25)
                .Must(IsValidName).WithMessage("{PropertyName} should be all letters.");

            // JUST FOR CONTROL
            RuleFor(p => p.LastName).NotEqual(p=>p.FirstName, StringComparer.Ordinal);

            RuleFor(p => p.Email)
                .EmailAddress();

            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!");
            RuleFor(x => x.DateOfBirth)
                .Must(AgeValidate)
                .WithMessage("Invalid {PropertyName}. Age must be 21 or greater than 21");
        }

        //  you could pass a number as the first name and the API would just say ‘Cool, that’s fine’.
        // This is done to prevent that
        private bool IsValidName(string name)
        {
            return name.All(char.IsLetter);
        }

        private bool AgeValidate(DateTime value)
        {
            var now = DateTime.Today;
            var age = now.Year - Convert.ToDateTime(value).Year;
            return age >= 21;
        }
    }
}