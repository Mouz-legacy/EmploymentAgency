using System.ComponentModel.DataAnnotations;

namespace TemplateStudio.Validation
{
    public class LastNameValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string lastName = value as string;
            this.ErrorMessageResourceName = null;
            if (lastName is null)
            {
                this.ErrorMessage = "Last name field not specified";
                return false;
            }
            else if (lastName.Length < 2 || lastName.Length > 30)
            {
                this.ErrorMessage = "Invalid last name value";
                return false;
            }
            else if (!char.IsUpper(lastName.ToCharArray()[0]))
            {
                this.ErrorMessage = "Last name must begin with an upper case letter";
                return false;
            }

            return true;
        }
    }
}
