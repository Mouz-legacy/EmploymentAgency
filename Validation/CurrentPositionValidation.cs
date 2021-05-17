using System.ComponentModel.DataAnnotations;

namespace TemplateStudio.Validation
{
    public class CurrentPositionValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string currentPosition = value as string;
            this.ErrorMessageResourceName = null;
            if (currentPosition is null)
            {
                this.ErrorMessage = "Current position field not specified";
                return false;
            }
            else if (currentPosition.Length < 10 || currentPosition.Length > 50)
            {
                this.ErrorMessage = "Invalid position description";
                return false;
            }
            else if (!char.IsUpper(currentPosition.ToCharArray()[0]))
            {
                this.ErrorMessage = "Position must begin with an upper case letter";
                return false;
            }

            return true;
        }
    }
}
