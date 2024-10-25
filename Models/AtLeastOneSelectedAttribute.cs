using System.ComponentModel.DataAnnotations;

namespace Developer_Task.Models
{
    public class AtLeastOneSelectedAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var list = value as List<int>;
            if (list == null || list.Count == 0)
            {
                return new ValidationResult("At least one item must be selected.");
            }
            return ValidationResult.Success;
        }
    }
}
