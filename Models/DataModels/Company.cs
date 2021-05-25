using System.ComponentModel.DataAnnotations;

namespace TemplateStudio.Models.DataModels
{
    public class Company
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CompanyImage { get; set; }
    }
}
