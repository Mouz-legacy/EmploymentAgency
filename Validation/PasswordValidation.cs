using System.ComponentModel.DataAnnotations;

namespace TemplateStudio.Validation
{
    public class PasswordValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string password = value as string;
            this.ErrorMessageResourceName = null;
            if (password is null)
            {
                this.ErrorMessage = "Password field not specified";
                return false;
            }
            else if (password.Length < 10)
            {
                this.ErrorMessage = "Invlaid password length";
                return false;
            }

            return true;
        }
    }
}
