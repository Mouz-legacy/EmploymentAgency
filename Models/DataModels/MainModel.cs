using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateStudio.Helpers;
using TemplateStudio.Models.ModelInterfaces;
using Windows.UI.Xaml.Controls;

namespace TemplateStudio.Models
{
    internal class MainModel : Observable, IMainModel
    {
        private string _header;
        private string _text;
        private Image _newsImage;
        private Image _companyImage;

        public string Header
        {
            get => _header;
            set { Set(ref _header, value); }
        }

        public string Text
        {
            get => _text;
            set { Set(ref _text, value); }
        }

        public Image NewsImage
        {
            get => _newsImage;
            set { Set(ref _newsImage, value); }
        }

        public Image CompanyImage
        {
            get => _companyImage;
            set { Set(ref _companyImage, value); }
        }
    }
}
