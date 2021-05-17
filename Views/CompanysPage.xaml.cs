using System;

using TemplateStudio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TemplateStudio.Views
{
    public sealed partial class CompanysPage : Page
    {
        public CompanyViewModel ViewModel { get; } = new CompanyViewModel();

        public CompanysPage()
        {
            InitializeComponent();
        }
    }
}
