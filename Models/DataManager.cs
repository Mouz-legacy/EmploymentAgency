using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace TemplateStudio.Models
{
    public static class DataManager
    {
        public static ObservableCollection<MainModel> GetMainData()
        {
            var listData = new ObservableCollection<MainModel>();
            listData.Add(ReadData("3+", "n3.jpg"));
            listData.Add(ReadData("5+", "n5.jpg"));
            listData.Add(ReadData("6+", "n6.jpg"));
            listData.Add(ReadData("7+", "n7.jpg"));
            listData.Add(ReadData("8+", "n8.jpg"));
            listData.Add(ReadData("9+", "n9.jpg"));
            listData.Add(ReadData("12+", "n12.jpg"));
            listData.Add(ReadData("14+", "n14.jpg"));
            listData.Add(ReadData("16+", "n16.jpg"));
            listData.Add(ReadData("17+", "n17.jpg"));

            return listData;
        }

        private static MainModel ReadData(string path, string imagePath)
        {
            string pathHeader = "Data/" + path + "/header.txt";
            string pathText = "Data/" + path + "/text.txt";
            imagePath = "/Assets/Newsphoto/" + imagePath;
            var model = new MainModel();
            model.NewsImage = imagePath;
            using (var reader = new StreamReader(pathHeader))
            {
                model.Header = reader.ReadToEnd();
            }

            using (var reader = new StreamReader(pathText))
            {
                model.Text = reader.ReadToEnd();
            }

            return model;
        }
    }
}
