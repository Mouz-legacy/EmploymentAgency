using TemplateStudio.Models.DataModels;

namespace TemplateStudio.Models
{
    public class VacanciesModel
    {
        public Vacancies Vacancies { get; private set; }

        public VacanciesModel()
        {
            this.Vacancies = new Vacancies();
        }

        public VacanciesModel SetCompany(string company)
        {
            this.Vacancies.Company = company;
            return this;
        }

        public VacanciesModel SetImage(string source)
        {
            this.Vacancies.CompanyImageSource = source;
            return this;
        }

        public VacanciesModel SetDescription(string description)
        {
            this.Vacancies.Description = description;
            return this;
        }

        public VacanciesModel SetPosition(string position)
        {
            this.Vacancies.Position = position;
            return this;
        }
    }
}
