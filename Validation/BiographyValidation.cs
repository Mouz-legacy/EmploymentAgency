using System.ComponentModel.DataAnnotations;
using TemplateStudio.Models;

namespace TemplateStudio.Validation
{
    public class BiographyValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string biography = value as string;

            this.ErrorMessageResourceName = null;
            if (biography is null)
            {
                this.ErrorMessage = "Biography field not specified";
                return false;
            }
            else if (biography.Length < 50 || biography.Length > 1000)
            {
                this.ErrorMessage = "Invalid biography size";
                return false;
            }
            else if (!char.IsUpper(biography.ToCharArray()[0]))
            {
                this.ErrorMessage = "Biography must begin with an uppercase char";
                return false;
            }

            return true;
        }
    }
}
