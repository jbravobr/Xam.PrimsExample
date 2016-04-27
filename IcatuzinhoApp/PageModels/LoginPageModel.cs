using System;
using Xamarin.Forms;

namespace IcatuzinhoApp
{
    public class LoginPageModel : FreshMvvm.FreshBasePageModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public Command Signin { get; set; }

        private IUserService _userService;

        public LoginPageModel(IUserService userService)
        {
            _userService = userService;

            Signin = new Command(async () =>
                {
                    await CoreMethods.PushPageModel<HomePageModel>();
                });
        }
    }
}

