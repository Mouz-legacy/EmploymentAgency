using System;

using TemplateStudio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TemplateStudio.Views
{
    public sealed partial class SalaryPage : Page
    {
        public SalaryViewModel ViewModel { get; } = new SalaryViewModel();

        public SalaryPage()
        {
            InitializeComponent();
        }
    }
}
