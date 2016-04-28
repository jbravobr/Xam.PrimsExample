using Xamarin.Forms;
using PropertyChanged;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class LoginPageModel : FreshMvvm.FreshBasePageModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        IUserService _userService;

        public LoginPageModel(IUserService userService)
        {
            _userService = userService;
        }

        public Command Confirm
        {
            get
            {
                return new Command(() =>
               {
                   var tabPage = new FreshMvvm.FreshTabbedNavigationContainer("HomeContainer");
                   tabPage.AddTab<HomePageModel>("Home", "", null);
                   tabPage.AddTab<TravelPageModel>("Itinerário", "", null);

                   CoreMethods.SwitchOutRootNavigation("HomeContainer");
               });
            }
        }
    }
}

