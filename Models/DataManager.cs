using System.Collections.Generic;

namespace TemplateStudio.Models
{
    public static class DataManager
    {
        public static List<MainModel> GetMainData()
        {
            return new List<MainModel>
            {
                new MainModel
                {
                    Header = "MainHeader",
                    Text = "Here will be text",
                    NewsImage = "/Assets/Epam.png",
                },
                new MainModel
                {
                    Header = "MainHeader",
                    Text = "Here will be text",
                    NewsImage = "/Assets/Qulix.gif",
                },
                new MainModel
                {
                    Header = "MainHeader",
                    Text = "Here will be text",
                    NewsImage = "/Assets/Epam.png",
                }, 
            };
        }
    }
}
