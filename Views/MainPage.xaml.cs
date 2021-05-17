using TemplateStudio.ViewModels;
using Windows.UI.Xaml.Controls;

namespace TemplateStudio.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }

        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainViewModel(ref splitView);
        }
    }
}
