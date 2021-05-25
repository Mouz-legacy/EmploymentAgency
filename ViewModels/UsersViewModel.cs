using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TemplateStudio.Helpers;
using TemplateStudio.Models;
using TemplateStudio.Models.DataModels;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TemplateStudio.ViewModels
{
    public class UsersViewModel : Observable
    {
        #region --Fields--

        private readonly SplitView _splitView;
        private readonly SplitView _loginRegistryView;
        private readonly SplitView _offers;
        private ObservableCollection<User> Users;
        private Vacancies _vacancies = new Vacancies();
        private UsersModel _user;
        private string _login;
        private string _password;
        private const string _path = "Users.txt";

        #endregion

        #region --Properties--

        public ObservableCollection<Vacancies> Vacancies { get; set; }

        public string Password
        {
            get => _password;
            set { Set(ref _password, value); }
        }

        public string Login
        {
            get => _login;
            set { Set(ref _login, value); }
        }

        public UsersModel User
        {
            get => _user;
            set { Set(ref _user, value); }
        }

        public Vacancies SelectedVacancies
        {
            get => _vacancies;
            set { Set(ref _vacancies, value); }
        }

        #endregion

        public UsersViewModel(ref SplitView view, ref SplitView login, ref SplitView offers)
        {
            _splitView = view;
            _loginRegistryView = login;
            _offers = offers;
            GetVacancies();
            GetUsers();
        }

        public async void GetVacancies()
        {
            try
            {
                Vacancies = new ObservableCollection<Vacancies>();
                var storageFolder = ApplicationData.Current.LocalCacheFolder;
                var file = await storageFolder.GetFileAsync("Vacancies.txt");
                string text = await FileIO.ReadTextAsync(file);
                var fields = text.Split("'");
                for (int i = 1, j = 2, k = 4, f = 6; i < fields.Length; i += 8)
                {
                    Vacancies.Add(new Vacancies
                    {
                        Company = fields[i],
                        CompanyImageSource = fields[i + j],
                        Description = fields[i + k],
                        Position = fields[f + i],
                    });
                }
            }
            catch (Exception exception)
            {
                var message = new MessageDialog($"Error has occurred: {exception.Message}");
                await message.ShowAsync();
            }
        }

        public void CompanyList_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectedVacancies = (Vacancies)e.ClickedItem;
            _offers.IsPaneOpen = !_offers.IsPaneOpen;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            _splitView.IsPaneOpen = !_splitView.IsPaneOpen;
        }

        public async void Accept_Vacancy(object sender, RoutedEventArgs e)
        {
            try
            {
                _offers.IsPaneOpen = !_offers.IsPaneOpen;
                var message = new MessageDialog("Your request was successfully accepted!");
                await message.ShowAsync();
            }
            catch (Exception exception)
            {
                await new MessageDialog($"Error has occurred: {exception.Message}").ShowAsync();
            }
        }

        public async void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = new
                {
                    Password = Password,
                    Login = Login,
                };
                var users = Users.Where(a => a.Password == data.Password && a.Email == data.Login).ToList();
                if (users.Count != 0)
                {
                    Password = string.Empty;
                    Login = string.Empty;
                    User.SetUser(users[0]);
                    _splitView.IsPaneOpen = !_splitView.IsPaneOpen;
                }
                else
                {
                    var message = new MessageDialog("Passwords were incorrect or user doesn't exist");
                    await message.ShowAsync();
                }
            }
            catch (Exception exception)
            {
                var message = new MessageDialog($"Error has occured: {exception.Message}");
                await message.ShowAsync();
            }
        }

        public void CloseOffer_Click(object sender, RoutedEventArgs e)
        {
            _offers.IsPaneOpen = !_offers.IsPaneOpen;
        }

        public void Login_Open(object sender, RoutedEventArgs e)
        {
            User = new UsersModel();
            _loginRegistryView.IsPaneOpen = !_loginRegistryView.IsPaneOpen;
        }

        public async void Validate_Registry(object sender, RoutedEventArgs e)
        {
            try
            {
                var results = new List<ValidationResult>();
                var context = new ValidationContext(_user.User);
                if (!Validator.TryValidateObject(_user.User, context, results, true))
                {
                    string errorMessage = "Some fields where wrong!";
                    foreach (var result in results)
                    {
                        errorMessage = string.Concat(errorMessage, $"\n{result}");
                    }

                    var message = new MessageDialog(errorMessage);
                    await message.ShowAsync();
                }
                else if (Password != _user.User.Password)
                {
                    var message = new MessageDialog("Passwords were incorrect!");
                    await message.ShowAsync();
                }
                else
                {
                    Users.Add(new User
                    {
                        FirstName = _user.User.FirstName,
                        LastName = _user.User.LastName,
                        Password = _user.User.Password,
                        ImageSource = _user.User.ImageSource,
                        GitHubLink = _user.User.GitHubLink,
                        GitLabLink = _user.User.GitLabLink,
                        LinkedinLink = _user.User.LinkedinLink,
                        MobilePhoneNumber = _user.User.MobilePhoneNumber,
                        HomePhoneNumber = _user.User.HomePhoneNumber,
                        Email = _user.User.Email,
                        CurrentPosition = _user.User.CurrentPosition,
                        Biography = _user.User.Biography,
                        Age = _user.User.Age,
                        PositionDescription = _user.User.PositionDescription,
                        StackOfTechnologies = _user.User.StackOfTechnologies,
                        SoftSkillFifth = _user.User.SoftSkillFifth,
                        SoftSkillFirst = _user.User.SoftSkillFirst,
                        SoftSkillSecond = _user.User.SoftSkillSecond,
                        SoftSkillFourth = _user.User.SoftSkillFourth,
                        SoftSkillThird = _user.User.SoftSkillThird,
                    });
                    LoadUser(_user);
                    _user = null;
                    var message = new MessageDialog("Verification completed! Your account has been successfully registered");
                    _loginRegistryView.IsPaneOpen = !_loginRegistryView.IsPaneOpen;
                    await message.ShowAsync();
                }
            }
            catch (Exception exception)
            {
                var message = new MessageDialog(exception.Message);
                await message.ShowAsync();
            }
        }

        private async void LoadUser(UsersModel user)
        {
            try
            {
                var storageFolder = ApplicationData.Current.LocalCacheFolder;
                var file = await storageFolder.GetFileAsync(_path);
                string userString = JsonConvert.SerializeObject(user);
                await FileIO.WriteTextAsync(file, userString);
            }
            catch (Exception e)
            {
                var message = new MessageDialog($"Error has occurred: {e.Message}");
                await message.ShowAsync();
            }
        }

        private async void GetUsers()
        {
            try
            {
                Users = new ObservableCollection<User>();
                var storageFolder = ApplicationData.Current.LocalCacheFolder;
                var file = await storageFolder.GetFileAsync(_path);
                var listUsers = FileIO.ReadLinesAsync(file).GetResults().ToList();
                foreach (var user in listUsers)
                {
                    var deserializedUser = JsonConvert.DeserializeObject<UsersModel>(user);
                    Users.Add(deserializedUser.User);
                }

                _user = new UsersModel();
                _user.SetUser(Users[0]);
            }
            catch (Exception e)
            {
                var message = new MessageDialog($"Error has occurred: {e.Message}");
                await message.ShowAsync();
            }
        }
    }
}
