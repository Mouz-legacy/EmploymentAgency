using System.ComponentModel.DataAnnotations;

namespace TemplateStudio.Validation
{
    public class SkillsValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string skill = value as string;
            this.ErrorMessageResourceName = null;
            if (skill is null)
            {
                this.ErrorMessage = "Skills fields not specified";
                return false;
            }
            else if (skill.Length < 2 || skill.Length > 30)
            {
                this.ErrorMessage = "Invalid fields value";
                return false;
            }
            else if (!char.IsUpper(skill.ToCharArray()[0]))
            {
                this.ErrorMessage = "Skill must begin with an upper case letter";
                return false;
            }

            return true;
        }
    }
}
