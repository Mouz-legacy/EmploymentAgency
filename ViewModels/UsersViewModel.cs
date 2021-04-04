using System;

using TemplateStudio.Helpers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace TemplateStudio.ViewModels
{
    public class UsersViewModel : Observable
    {
        public string ButtonRegistry { get; } = "Registry new account";

        public UsersViewModel()
        {
            
        }
    }
}
