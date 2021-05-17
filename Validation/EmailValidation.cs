using System.ComponentModel.DataAnnotations;

namespace TemplateStudio.Validation
{
    public class EmailValidation  : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string email = value as string;
            this.ErrorMessageResourceName = null;
            if (email is null)
            {
                this.ErrorMessage = "Email field not specified";
                return false;
            }
            else if (email.Length < 5)
            {
                this.ErrorMessage = "Invalid email length";
                return false;
            }

            var emailParts = email.Split('@');
            if (!email.Contains("@") || emailParts.Length != 2)
            {
                this.ErrorMessage = "This is not a email";
                return false;
            }
            else if (emailParts[1].Length < 5)
            {
                this.ErrorMessage = "Wrong email domen";
                return false;
            }

            return true;
        }
    }
}
