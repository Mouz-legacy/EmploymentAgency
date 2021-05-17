using System.Collections.ObjectModel;
using TemplateStudio.Helpers;
using TemplateStudio.Models;
using Windows.UI.Xaml.Controls;

namespace TemplateStudio.ViewModels
{
    public class MainViewModel : Observable
    {
        public ObservableCollection<MainModel> DataModel { get; set; } = new ObservableCollection<MainModel>();
        private SplitView _splitView;
        private MainModel _model = new MainModel { NewsImage = "/Assets/Newsphoto/n5.jpg" };
        public MainModel Model
        {
            get => _model;
            set { Set(ref _model, value); }
        }

        public MainViewModel(ref SplitView splitView)
        {
            DataModel = DataManager.GetMainData();
            _splitView = splitView;
        }

        public void ItemClick(object sender, ItemClickEventArgs e)
        {
            Model = (MainModel)e.ClickedItem;
            _splitView.IsPaneOpen = !_splitView.IsPaneOpen;
        }
    }
}
