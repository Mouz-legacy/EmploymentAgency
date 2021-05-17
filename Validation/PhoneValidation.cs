using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TemplateStudio.Validation
{
    class PhoneValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string phoneNumber = value as string;
            this.ErrorMessageResourceName = null;
            if (phoneNumber is null)
            {
                this.ErrorMessage = "Phone number fields is not specified";
                return false;
            }

            var regex = new Regex(@"\W+\d{1}\W(\d{3}\W)\d{7}");
            var mobileMathes = regex.Matches(phoneNumber);
            if (mobileMathes.Count == 0)
            {
                this.ErrorMessage = "Invalid phone number";
                return false;
            }

            return true;
        }
    }
}
