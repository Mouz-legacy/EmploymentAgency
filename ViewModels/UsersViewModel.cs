using System;

using TemplateStudio.Helpers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace TemplateStudio.ViewModels
{
    public class UsersViewModel : Observable
    {
        public string ButtonRegistry { get; } = "Registry new account";
        private readonly SplitView _splitView;

        public UsersViewModel(ref SplitView view)
        {
            _splitView = view;
        }

        public void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            _splitView.IsPaneOpen = !_splitView.IsPaneOpen;
        }
    }
}
