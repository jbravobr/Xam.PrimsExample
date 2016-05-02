using Xamarin.Forms;
using PropertyChanged;
//using Acr.UserDialogs;
using Plugin.Toasts;
using System;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Reflection;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class LoginPageModel : FreshMvvm.FreshBasePageModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool EmailError { get; set; }

        public bool PasswordError { get; set; }

        readonly IUserService _userService;

        readonly IScheduleService _scheduleService;

        readonly IStationService _stationService;

        readonly ITravelService _travelService;

        //IUserDialogs _userDialogs;

        public LoginPageModel(IUserService userService,
                              IScheduleService scheduleService,
                              IStationService stationService,
                              ITravelService travelService)
        {
            _userService = userService;
            _scheduleService = scheduleService;
            _stationService = stationService;
            _travelService = travelService;
            //_userDialogs = userDialogs;

            EmailError = false;
            PasswordError = false;
        }

        public async override void Init(object initData)
        {
            base.Init(initData);

            if (await GetAuthenticatedUser())
            {
                await RegisterLocalAuthenticatedUser();

                var tabPage = new FreshMvvm.FreshTabbedNavigationContainer("HomeContainer");
                tabPage.AddTab<HomePageModel>("Home", "house-full.png", null);
                tabPage.AddTab<TravelPageModel>("Itinerário", "bus-full.png", null);

                CoreMethods.SwitchOutRootNavigation("HomeContainer");
            }
        }


        public async Task<bool> GetAuthenticatedUser()
        {
            return await _userService.GetAuthenticatedUser();
        }

        public Command Confirm
        {
            get
            {
                return new Command(async (obj) =>
               {
                   if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password))
                   {
                       EmailError = true;
                       PasswordError = true;
                       return;
                   }
                   else if (string.IsNullOrEmpty(Email))
                   {
                       EmailError = true;
                       return;
                   }
                   else if (string.IsNullOrEmpty(Password))
                   {
                       PasswordError = true;
                       return;
                   }
                   else
                   {
                       EmailError = false;
                       PasswordError = false;

                       var userAuthenticated = await _userService.Login(Email, Password);

                       if (userAuthenticated)
                       {
                           try
                           {
                               await _stationService.GetAllStations();
                               await _scheduleService.GetAllSchedules();
                               await InsertTravels();

                               var tabPage = new FreshMvvm.FreshTabbedNavigationContainer("HomeContainer");
                               tabPage.AddTab<HomePageModel>("Home", "house-full.png", null);
                               tabPage.AddTab<TravelPageModel>("Itinerário", "bus-full.png", null);

                               await RegisterLocalAuthenticatedUser();

                               CoreMethods.SwitchOutRootNavigation("HomeContainer");
                           }
                           catch (Exception ex)
                           {
                               new LogExceptionService().SubmitToInsights(ex);
                           }
                       }
                       else
                       {
                           //await _userDialogs.AlertAsync(string.Empty, "Usuário/Senha inválidos");
                           await DependencyService.Get<IToastNotificator>().Notify(ToastNotificationType.Error,
                               "Usuário/Senha inválidos", string.Empty, TimeSpan.FromSeconds(4));
                       }
                   }
               });
            }
        }

        public async Task RegisterLocalAuthenticatedUser()
        {
            var user = await _userService.GetAllAsync();

            if (user != null)
                App.UserAuthenticated = user;
        }

        public async Task InsertTravels()
        {
            var schedules = await _scheduleService.GetAllWithChildrenAsync();

            if (schedules != null && schedules.Any())
            {
                foreach (var schedule in schedules)
                {
                    if (schedule != null)
                    {
                        await _travelService.GetTravelByScheduleId(schedule.Id);
                    }
                }
            }
        }

        public void TextChangedEmail()
        {
            EmailError = false;
        }

        public void TextChangedPassword()
        {
            PasswordError = false;
        }
    }
}

