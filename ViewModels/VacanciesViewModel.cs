using System;
using System.Collections.ObjectModel;
using TemplateStudio.Helpers;
using TemplateStudio.Models;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace TemplateStudio.ViewModels
{
    public class VacanciesViewModel : Observable
    {
        #region --Fields--

        private VacanciesModel _selectedVacancies;

        #endregion

        #region --Properties--

        private SplitView splitView { get; set; }

        public ObservableCollection<VacanciesModel> Vacancies { get; set; }

        public VacanciesModel SelectedVacancies
        {
            get => _selectedVacancies;
            set
            {
                Set(ref _selectedVacancies, value);
            }
        }


        #endregion

        public VacanciesViewModel(ref SplitView splitView)
        {
            Vacancies = new ObservableCollection<VacanciesModel>();
            this.splitView = splitView;
            LoadData();
        }

        public void Vacancies_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectedVacancies = (VacanciesModel)e.ClickedItem;
            this.splitView.IsPaneOpen = !this.splitView.IsPaneOpen;
        }

        public async void LoadData()
        {
            try
            {
                var storageFolder = ApplicationData.Current.LocalCacheFolder;
                var file = await storageFolder.GetFileAsync("VacanciesAll.txt");
                string text = await FileIO.ReadTextAsync(file);
                var fields = text.Split("'");
                for (int i = 0, j = 1, k = 2, l = 3; i < fields.Length; i += 4)
                {
                    Vacancies.Add(new VacanciesModel()
                        .SetImage(fields[i])
                        .SetCompany(fields[i + j])
                        .SetDescription(fields[i + k])
                        .SetPosition(fields[i + l]));
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
