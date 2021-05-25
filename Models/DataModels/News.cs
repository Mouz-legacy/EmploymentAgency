using System.ComponentModel.DataAnnotations;

namespace TemplateStudio.Models.DataModels
{
    public class News
    {
        [Required]
        public string Header { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string NewsImage { get; set; }
    }
}
