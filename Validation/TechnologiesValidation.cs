using System.ComponentModel.DataAnnotations;

namespace TemplateStudio.Validation
{
    public class TechnologiesValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var source = value as string;
            this.ErrorMessageResourceName = null;
            if (source is null)
            {
                this.ErrorMessage = "Technology field not specified";
                return false;
            }
            else if (source.Length < 20)
            {
                this.ErrorMessage = "Choose 5 technologies";
                return false;
            }

            return true;
        }
    }
}
