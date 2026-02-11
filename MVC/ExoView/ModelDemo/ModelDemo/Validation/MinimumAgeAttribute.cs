using System.ComponentModel.DataAnnotations;

namespace ModelDemo.Validation
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
            ErrorMessage = $"Vous devez avoir au moins {minimumAge} ans";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateNaissance) { 
                var age = DateTime.Now.Year - dateNaissance.Year;

                if (dateNaissance > DateTime.Now.AddYears(-age))
                {
                    age--;
                }

                if(age >= _minimumAge)
                {
                    return ValidationResult.Success;
                }

            }
            return new ValidationResult(ErrorMessage);
        }
    }
}
