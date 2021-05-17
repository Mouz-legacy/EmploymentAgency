using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TemplateStudio.Models.DataModels
{
    public class Vacancies : INotifyPropertyChanged
    {
        [Required]
        public string Company { get; set; }
        [Required]
        public string CompanyImageSource { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Position { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
