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
                   tabPage.AddTab<HomePageModel>("Home", "house-full.png", null);
                   tabPage.AddTab<TravelPageModel>("Itinerário", "bus-full.png", null);

                //return new Command(async () =>
                //{
                    //var page = new FreshMvvm.FreshTabbedNavigationContainer();

					//page.AddTab<HomePageModel>("Home", "monkeyicon.png", null);
                    //page.AddTab<TravelPageModel>("Itinerário", "", null);

                   CoreMethods.SwitchOutRootNavigation("HomeContainer");
               });
            }
        }
    }
}

