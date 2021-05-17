using System.ComponentModel.DataAnnotations;

namespace TemplateStudio.Validation
{
    public class FirstNameValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string firstName = value as string;
            this.ErrorMessageResourceName = null;
            if (firstName is null)
            {
                this.ErrorMessage = "First name field not specified";
                return false;
            }
            else if (firstName.Length < 2 || firstName.Length > 30)
            {
                this.ErrorMessage = "Invalid first name value";
                return false;
            }
            else if (!char.IsUpper(firstName.ToCharArray()[0]))
            {
                this.ErrorMessage = "First name must begin with an upper case letter";
                return false;
            }

            return true;
        }
    }
}
