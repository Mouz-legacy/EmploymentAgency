using System;
using System.Collections.Generic;
using TemplateStudio.Helpers;
using TemplateStudio.Models;
using Windows.UI.Xaml.Controls;

namespace TemplateStudio.ViewModels
{
    public class MainViewModel : Observable
    {
        public List<MainModel> DataModel { get; set; } = new List<MainModel>();
        private SplitView _splitView;
        public string PaneImageContent { get; private set; }
        public string TextContent { get; private set; }

        public MainViewModel(ref SplitView splitView)
        {
            DataModel = DataManager.GetMainData();
            _splitView = splitView;
            PaneImageContent = DataModel[0].NewsImage;
            TextContent = DataModel[0].Text;
        }

        public void ItemClick(object sender, ItemClickEventArgs e)
        {
            _splitView.IsPaneOpen = !_splitView.IsPaneOpen;
            string newsItem = e.ClickedItem.ToString();
            //Linq to DataModel
        }

        public void OnNewsClick(object sender, ItemClickEventArgs e)//Клики на обеих GridView
        {

        }

        public void NewsItemClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
