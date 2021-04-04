using System;

using TemplateStudio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TemplateStudio.Views
{
    public sealed partial class UsersPage : Page
    {
        public UsersViewModel ViewModel { get; }

        public UsersPage()
        {
            InitializeComponent();
            ViewModel = new UsersViewModel();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            openHelpPanel.IsPaneOpen = !openHelpPanel.IsPaneOpen;
        }
    }
}
