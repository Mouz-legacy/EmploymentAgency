using System;

using TemplateStudio.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TemplateStudio.Views
{
    public sealed partial class VacanciesPage : Page
    {
        public VacanciesViewModel ViewModel { get; } = new VacanciesViewModel();

        public VacanciesPage()
        {
            InitializeComponent();
        }
    }
}
