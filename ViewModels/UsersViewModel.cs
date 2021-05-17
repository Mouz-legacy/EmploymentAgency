using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using TemplateStudio.Helpers;
using TemplateStudio.Models;
using TemplateStudio.Models.DataModels;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using System;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;

namespace TemplateStudio.ViewModels
{
    public class UsersViewModel : Observable
    {
        #region --Fields--

        private readonly SplitView _splitView;
        private readonly SplitView _loginRegistryView;
        private readonly SplitView _avaliableOffersView;
        private readonly SplitView _offers; 
        private ObservableCollection<User> Users = new ObservableCollection<User>();
        private Vacancies _vacancies = new Vacancies();
        private UsersModel _user;

        #endregion

        #region --Properties--

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

        public ObservableCollection<Vacancies> Vacancies { get; set; }
        public string Password { get; set; }

        #endregion

        public UsersViewModel(ref SplitView view, ref SplitView login, ref SplitView offers)
        {
            _splitView = view;
            _loginRegistryView = login;
            _offers = offers;
            _user = GetDefaultUserValues();
            Vacancies = GetVacancies();
        }

        public ObservableCollection<Vacancies> GetVacancies()
        {
            var vacancies = new ObservableCollection<Vacancies>();
            for (int i = 0; i < 10; i++)
            {
                vacancies.Add(new Vacancies
                {
                    Company = "Test company",
                    CompanyImageSource = "/Assets/Qulix.gif",
                    Description = "Here will be normal description",
                    Position = "Junior Developer",
                });
            }

            return vacancies;
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

        public void CloseOffer_Click(object sender, RoutedEventArgs e)
        {
            _offers.IsPaneOpen = !_offers.IsPaneOpen;
        }

        public void Login_OpenClose(object sender, RoutedEventArgs e)
        {
            User = new UsersModel();
            _loginRegistryView.IsPaneOpen = !_loginRegistryView.IsPaneOpen;
        }

        public async void Validate_Regisrty(object sender, RoutedEventArgs e)
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

        private UsersModel GetDefaultUserValues()
        {
            return new UsersModel()
                .SetPositionDescription("Part of Epam Systems since December 10, 2012.")
                .SetName("Alexey")
                .SetSurname("Strelets")
                .SetCurrentPosition("Junior .Net Developer")
                .SetEmail("streletswork@gmail.com")
                .SetHomePhone("+8(029)1449927")
                .SetMobilePhone("+8(029)1449927")
                .SetImageSource("/Assets/Default.png")
                .SetSoftFirstSkill("Clear Communication")
                .SetSoftSecondSkill("Problem solving")
                .SetSoftThirdSkill("Empathy")
                .SetSoftFourthSkill("Time management")
                .SetSoftFifthSkill("Optimism");
        }
    }
}
