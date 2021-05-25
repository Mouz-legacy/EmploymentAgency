using System;
using TemplateStudio.Models.DataModels;

namespace TemplateStudio.Models
{
    [Serializable]
    public class UsersModel
    {
        public User User { get; private set; }

        public UsersModel()
        {
            this.User = new User();
        }

        public void SetUser(User user)
        {
            this.User = user;
        }

        public UsersModel SetName(string name)
        {
            this.User.FirstName = name;
            return this;
        }

        public UsersModel SetSurname(string surname)
        {
            this.User.LastName = surname;
            return this;
        }

        public UsersModel SetCurrentPosition(string currentPosition)
        {
            this.User.CurrentPosition = currentPosition;
            return this;
        }

        public UsersModel SetPositionDescription(string position)
        {
            this.User.PositionDescription = position;
            return this;
        }

        public UsersModel SetEmail(string email)
        {
            this.User.Email = email;
            return this;
        }

        public UsersModel SetGitHub(string github)
        {
            this.User.GitHubLink = new Uri(github);
            return this;
        }

        public UsersModel SetGitLab(string gitlab)
        {
            this.User.GitLabLink = new Uri(gitlab);
            return this;
        }

        public UsersModel SetLinkedIn(string linkedIn)
        {
            this.User.LinkedinLink = new Uri(linkedIn);
            return this;
        }

        public UsersModel SetBiography(string biography)
        {
            this.User.Biography = biography;
            return this;
        }

        public UsersModel SetAge(int age)
        {
            this.User.Age = age;
            return this;
        }

        public UsersModel SetMobilePhone(string phone)
        {
            this.User.MobilePhoneNumber = phone;
            return this;
        }

        public UsersModel SetHomePhone(string phone)
        {
            this.User.HomePhoneNumber = phone;
            return this;
        }

        public UsersModel SetPassword(string password)
        {
            this.User.Password = password;
            return this;
        }

        public UsersModel SetStackOfTechnologies(string technologies)
        {
            this.User.StackOfTechnologies = technologies;
            return this;
        }

        public UsersModel SetImageSource(string source)
        {
            this.User.ImageSource = source;
            return this;
        }

        public UsersModel SetSoftFirstSkill(string skill)
        {
            this.User.SoftSkillFirst = skill;
            return this;
        }

        public UsersModel SetSoftSecondSkill(string skill)
        {
            this.User.SoftSkillSecond = skill;
            return this;
        }

        public UsersModel SetSoftThirdSkill(string skill)
        {
            this.User.SoftSkillThird = skill;
            return this;
        }

        public UsersModel SetSoftFourthSkill(string skill)
        {
            this.User.SoftSkillFourth = skill;
            return this;
        }

        public UsersModel SetSoftFifthSkill(string skill)
        {
            this.User.SoftSkillFifth = skill;
            return this;
        }
    }
}
