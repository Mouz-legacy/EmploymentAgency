using System;
using System.ComponentModel.DataAnnotations;
using TemplateStudio.Models;

namespace TemplateStudio.Validation
{
    public class LinkValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Uri link = value as Uri;
            this.ErrorMessageResourceName = null;
            if (link is null)
            {
                this.ErrorMessage = "Links fields not specified";
                return false;
            }
            else if (!link.AbsoluteUri.Contains("github/")
                && !link.AbsoluteUri.Contains("gitlab/")
                && !link.AbsoluteUri.Contains("linkedin.com/in/"))
            {
                this.ErrorMessage = "Invalid link";
                return false;
            }

            return true;
        }
    }
}
