using System;
using System.Collections.ObjectModel;
using TemplateStudio.Helpers;
using TemplateStudio.Models;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace TemplateStudio.ViewModels
{
    public class CompanyViewModel : Observable
    {
        #region --Fields--

        private SplitView _splitView;
        private CompanyModel _selectedModel;

        #endregion

        #region --Properties

        public ObservableCollection<CompanyModel> Companys { get; set; }

        public CompanyModel SelectedModel
        {
            get => _selectedModel;
            set
            {
                Set(ref _selectedModel, value);
            }
        }

        #endregion


        public CompanyViewModel(ref SplitView splitView)
        {
            _splitView = splitView;
            LoadCompanys();
        }

        public void CompanyList_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectedModel = (CompanyModel)e.ClickedItem;
            _splitView.IsPaneOpen = !_splitView.IsPaneOpen;
        }

        private async void LoadCompanys()
        {
            try
            {
                Companys = new ObservableCollection<CompanyModel>();
                var storageFolder = ApplicationData.Current.LocalCacheFolder;
                var file = await storageFolder.GetFileAsync("Companys.txt");
                string text = await FileIO.ReadTextAsync(file);
                var fields = text.Split("'");
                for (int i = 0, j = 1, k = 2; i < fields.Length; i += 3)
                {
                    Companys.Add(new CompanyModel()
                        .SetCompanyImage(fields[i])
                        .SetCompanyDescription(fields[i + j])
                        .SetCompanyName(fields[i + k]));
                }
            }
            catch (Exception exception)
            {
                var message = new MessageDialog($"Error has occurred: {exception.Message}");
                await message.ShowAsync();
            }
        }
    }
 }
