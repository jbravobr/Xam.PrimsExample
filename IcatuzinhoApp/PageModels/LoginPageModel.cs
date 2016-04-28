using System;
using Xamarin.Forms;

namespace IcatuzinhoApp
{
    public class LoginPageModel : FreshMvvm.FreshBasePageModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        IUserService _userService;

        public LoginPageModel(IUserService userService)
        {
            _userService = userService;
        }

        public Command Signin
        {
            get
            {
                return new Command(async () =>
                {
                    var page = new FreshMvvm.FreshTabbedNavigationContainer();
                    page.AddTab<HomePageModel>("Home", "");
                    page.AddTab<TravelPageModel>("Itinerário", "");

                    await CoreMethods.PushNewNavigationServiceModal(page, null);
                });
            }
        }
    }
}

