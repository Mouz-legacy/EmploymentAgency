using System.Collections.Generic;
using TemplateStudio.ViewModels;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

namespace TemplateStudio.Views
{
    public class SmartPhone
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }

    public sealed partial class SalaryPage : Page
    {
        public SalaryViewModel ViewModel { get; } = new SalaryViewModel();

        public SalaryPage()
        {
            InitializeComponent();
            LoadChartContens();
        }

        private void LoadChartContens()
        {
            var list = new List<SmartPhone>();
            list.Add(new SmartPhone
            {
                Name = "Iphone",
                Amount = 500,
            });
            list.Add(new SmartPhone
            {
                Name = "Samsung",
                Amount = 400,
            });
            list.Add(new SmartPhone
            {
                Name = "LG",
                Amount = 600,
            });
            (ColumnChart.Series[0] as ColumnSeries).ItemsSource = list;
        }
    }
}
