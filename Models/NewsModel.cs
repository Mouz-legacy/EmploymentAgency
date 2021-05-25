using TemplateStudio.Models.DataModels;

namespace TemplateStudio.Models
{
    public class NewsModel
    {
        public News News { get; private set; }

        public NewsModel()
        {
            this.News = new News();
        }

        public NewsModel SetHeader(string header)
        {
            this.News.Header = header;
            return this;
        }

        public NewsModel SetImage(string source)
        {
            this.News.NewsImage = source;
            return this;
        }

        public NewsModel SetText(string text)
        {
            this.News.Text = text;
            return this;
        }
    }
}
