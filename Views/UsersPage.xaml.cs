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
            ViewModel = new UsersViewModel(ref this.openHelpPanel);
        }
    }
}
