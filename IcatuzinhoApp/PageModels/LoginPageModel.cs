using Xamarin.Forms;
using PropertyChanged;
using Plugin.Toasts;
using System;
using System.Threading.Tasks;
using System.Linq;
using Acr.UserDialogs;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class LoginPageModel : BasePageModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool EmailError { get; set; }

        public bool PasswordError { get; set; }

        readonly IUserService _userService;

        readonly IScheduleService _scheduleService;

        readonly IStationService _stationService;

        readonly ITravelService _travelService;

        readonly IWeatherService _weatherService;

        readonly IUserDialogs _userDialogs;

        public LoginPageModel(IUserService userService,
                              IScheduleService scheduleService,
                              IStationService stationService,
                              ITravelService travelService,
                              IWeatherService weatherService,
                              IUserDialogs userDialogs)
        {
            _userService = userService;
            _scheduleService = scheduleService;
            _stationService = stationService;
            _travelService = travelService;
            _weatherService = weatherService;
            _userDialogs = userDialogs;

            EmailError = false;
            PasswordError = false;
        }

        public async override void Init(object initData)
        {
            base.Init(initData);

            try
            {
                if (await GetAuthenticatedUser())
                {
                    _userDialogs.ShowLoading();
                    await _weatherService.GetWeather();

                    RegisterLocalAuthenticatedUser();

                    var tabPage = new FreshMvvm.FreshTabbedNavigationContainer("HomeContainer");
                    tabPage.AddTab<HomePageModel>("Home", "house-full.png", null);
                    tabPage.AddTab<TravelPageModel>("Itinerário", "bus-full.png", null);
                    _userDialogs.HideLoading();

                    CoreMethods.SwitchOutRootNavigation("HomeContainer");
                }
            }
            catch (Exception ex)
            {
                _userDialogs.HideLoading();
                new LogExceptionService().SubmitToInsights(ex);
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
                   try
                   {
                       _userDialogs.ShowLoading();
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
                                   await _weatherService.GetWeather();

                                   var tabPage = new FreshMvvm.FreshTabbedNavigationContainer("HomeContainer");
                                   tabPage.AddTab<HomePageModel>("Home", "house-full.png", null);
                                   tabPage.AddTab<TravelPageModel>("Itinerário", "bus-full.png", null);

                                   RegisterLocalAuthenticatedUser();

                                   _userDialogs.HideLoading();
                                   CoreMethods.SwitchOutRootNavigation("HomeContainer");
                               }
                               catch (Exception ex)
                               {
                                   _userDialogs.HideLoading();
                                   new LogExceptionService().SubmitToInsights(ex);
                               }
                           }
                           else
                           {
                               await DependencyService.Get<IToastNotificator>().Notify(ToastNotificationType.Error,
                                   "Usuário/Senha inválidos", string.Empty, TimeSpan.FromSeconds(4));
                           }
                       }
                   }
                   catch (Exception ex)
                   {
                       base.SendToInsights(ex);
                   }
               });
            }
        }

        public void RegisterLocalAuthenticatedUser()
        {
            var user = _userService.GetAll();

            if (user != null && user.Any())
                App.UserAuthenticated = user.FirstOrDefault();
        }

        public async Task InsertTravels()
        {
            var schedules = _scheduleService.GetAllWithChildren();

            if (schedules != null && schedules.Any())
            {
                foreach (var schedule in schedules)
                {
                    if (schedule != null)
                        await _travelService.GetTravelByScheduleId(schedule.Id);
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

