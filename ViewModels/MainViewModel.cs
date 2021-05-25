using System;
using System.Collections.ObjectModel;
using TemplateStudio.Helpers;
using TemplateStudio.Models;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace TemplateStudio.ViewModels
{
    public class MainViewModel : Observable
    {
        #region --Fields--

        private SplitView _splitView;
        private NewsModel _model;
        private string _path = "News.txt";
        private string _baseNews = "/Assets/2.jpg";

        #endregion

        #region --Properties--

        public ObservableCollection<NewsModel> DataModel { get; set; } = new ObservableCollection<NewsModel>();

        public NewsModel Model
        {
            get => _model;
            set { Set(ref _model, value); }
        }

        #endregion

        public MainViewModel(ref SplitView splitView)
        {
            _splitView = splitView;
            _model = new NewsModel();
            _model.SetImage(_baseNews);
            LoadData();
        }

        public void ItemClick(object sender, ItemClickEventArgs e)
        {
            Model = (NewsModel)e.ClickedItem;
            _splitView.IsPaneOpen = !_splitView.IsPaneOpen;
        }

        public async void LoadData()
        {
            try
            {
                var storageFolder = ApplicationData.Current.LocalCacheFolder;
                var file = await storageFolder.GetFileAsync(_path);
                string text = await FileIO.ReadTextAsync(file);
                var fields = text.Split("'");
                for (int i = 0, j = 1, k = 2; i < fields.Length; i += 3)
                {
                    DataModel.Add(new NewsModel()
                        .SetHeader(fields[i])
                        .SetImage(fields[i + j])
                        .SetText(fields[i + k]));
                }
            }
            catch (Exception exception)
            {
                var message = new MessageDialog($"Error has occurred: {exception.Message}");
                await message.ShowAsync();
            }
        }
    }
}
