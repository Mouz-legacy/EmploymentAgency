using System;

using TemplateStudio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TemplateStudio.Views
{
    public sealed partial class CompanysPage : Page
    {
        public CompanysViewModel ViewModel { get; } = new CompanysViewModel();

        public CompanysPage()
        {
            InitializeComponent();
        }
    }
}
