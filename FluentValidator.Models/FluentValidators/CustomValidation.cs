using System;
using System.Linq;

namespace FluentValidator.Models.FluentValidators
{
    public class CustomValidation
    {
        //  you could pass a number as the first name and the API would just say ‘Cool, that’s fine’.
        // This is done to prevent that
        public static bool IsValidName(string name)
        {
            return name.All(char.IsLetter);
        }

        public static bool AgeValidate(DateTime value)
        {
            var now = DateTime.Today;
            var age = now.Year - Convert.ToDateTime(value).Year;
            return age >= 21;
        }
    }
}