using TemplateStudio.Models.DataModels;

namespace TemplateStudio.Models
{
    public class CompanyModel
    {
        public Company Company { get; private set; }

        public CompanyModel()
        {
            this.Company = new Company();
        }

        public CompanyModel SetCompany(Company company)
        {
            this.Company = company;
            return this;
        }

        public CompanyModel SetCompanyName(string name)
        {
            this.Company.Name = name;
            return this;
        }

        public CompanyModel SetCompanyDescription(string description)
        {
            this.Company.Description = description;
            return this;
        }

        public CompanyModel SetCompanyImage(string source)
        {
            this.Company.CompanyImage = source;
            return this;
        }
    }
}
