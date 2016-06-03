using System;
using Acr.UserDialogs;
using Xamarin.Forms;
using Prism.Commands;
using Prism.Navigation;

namespace IcatuzinhoApp
{
    public class RegisterPageViewModel : BasePageViewModel
    {
        readonly IUserService _userService;
        readonly INavigationService _navigationService;

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DelegateCommand NavigateCommand { get; set; }

        public RegisterPageViewModel(IUserService userService, INavigationService navigationService)
        {
            _userService = userService;
            _navigationService = navigationService;

            NavigateCommand = new DelegateCommand(Navigate);
        }

        public Command Cadastrar
        {
            get
            {
                return new Command(async (obj) =>
                    {
                        if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email)
                        && !string.IsNullOrWhiteSpace(Password) && ValidateEmail())
                        {
                            var result = _userService.Insert(new User
                                {
                                    Email = Email, Name = Name, Password = Password
                                });

                            if (result)
                                await NavigateCommand.Execute();
                        }
                    });
            }
        }

        private bool ValidateEmail()
        {
            return Email.Split('@')[1].Contains("icatuseguros.com.br");
        }

        async void Navigate()
        {
            try
            {
                await _navigationService.Navigate("RegisterConfirmationPage", null, true);
            }
            catch (Exception ex)
            {
                UIFunctions.ShowErrorMessageToUI();
                base.SendToInsights(ex);
            }
        }
    }
}

