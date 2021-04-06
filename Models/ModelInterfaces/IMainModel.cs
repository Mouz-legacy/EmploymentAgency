using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TemplateStudio.Models.ModelInterfaces
{
    internal interface IMainModel
    {
        string Header { get; set; }
        string Text { get; set; }
        string NewsImage { get; set; }
    }
}
