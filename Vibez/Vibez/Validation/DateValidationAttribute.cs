using System.ComponentModel.DataAnnotations;

namespace Vibez.Validation
{
    public class DateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date.Date >= DateTime.Today;
            }

            return false;
        }
    }
}
