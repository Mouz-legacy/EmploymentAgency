using TemplateStudio.Models.ModelInterfaces;

namespace TemplateStudio.Models
{
    public class MainModel : IMainModel
    {
        public string Header { get; set; }
        public string Text { get; set; }
        public string NewsImage { get; set; }
    }
}
