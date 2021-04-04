using System;

using TemplateStudio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TemplateStudio.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
