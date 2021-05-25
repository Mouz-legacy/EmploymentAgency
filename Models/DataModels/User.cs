using System;
using System.ComponentModel.DataAnnotations;
using TemplateStudio.Validation;

namespace TemplateStudio.Models.DataModels
{
    [Serializable]
    public class User
    {
        [FirstNameValidation]
        public string FirstName { get; set; }
        [LastNameValidation]
        public string LastName { get; set; }
        [CurrentPositionValidation]
        public string CurrentPosition { get; set; }
        [Required(ErrorMessageResourceName = null, ErrorMessage = "Position description not specified")]
        public string PositionDescription { get; set; }
        [EmailValidation]
        public string Email { get; set; }
        [LinkValidation]
        public Uri GitHubLink { get; set; }
        [LinkValidation]
        public Uri GitLabLink { get; set; }
        [LinkValidation]
        public Uri LinkedinLink { get; set; }
        [BiographyValidation]
        public string Biography { get; set; }
        public int Age { get; set; }
        [PhoneValidation]
        public string MobilePhoneNumber { get; set; }
        [HomePhoneValidation]
        public string HomePhoneNumber { get; set; }
        [PasswordValidation]
        public string Password { get; set; }
        [TechnologiesValidation]
        public string StackOfTechnologies { get; set; }
        public string ImageSource { get; set; }
        [SkillsValidation]
        public string SoftSkillFirst { get; set; }
        [SkillsValidation]
        public string SoftSkillSecond { get; set; }
        [SkillsValidation]
        public string SoftSkillThird { get; set; }
        [SkillsValidation]
        public string SoftSkillFourth { get; set; }
        [SkillsValidation]
        public string SoftSkillFifth { get; set; }
    }
}
