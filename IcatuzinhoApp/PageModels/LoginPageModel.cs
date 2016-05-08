using Xamarin.Forms;
using PropertyChanged;
using System;
using System.Threading.Tasks;
using System.Linq;
using Acr.UserDialogs;
using Xamarin;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class LoginPageModel : BasePageModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool EmailIsEnabled { get; set; }

        public bool PasswordIsEnabled { get; set; }

        readonly IUserService _userService;

        readonly IAuthenticationService _authService;

        readonly IScheduleService _scheduleService;

        readonly IStationService _stationService;

        readonly ITravelService _travelService;

        readonly IWeatherService _weatherService;

        readonly IUserDialogs _userDialogs;

        readonly IItineraryService _itineraryService;

        public LoginPageModel(IUserService userService,
                              IScheduleService scheduleService,
                              IStationService stationService,
                              ITravelService travelService,
                              IWeatherService weatherService,
                              IUserDialogs userDialogs,
                              IItineraryService itineraryService,
                              IAuthenticationService authService)
        {
            _userService = userService;
            _scheduleService = scheduleService;
            _stationService = stationService;
            _userDialogs = userDialogs;
            _travelService = travelService;
            _weatherService = weatherService;
            _itineraryService = itineraryService;
            _authService = authService;

            EmailIsEnabled = true;
            PasswordIsEnabled = true;
        }

        public async override void Init(object initData)
        {
            base.Init(initData);
            await Logon();
        }

        public async Task Logon()
        {
            try
            {
                _userDialogs.ShowLoading("Verificando conexão");

                if (!await Connectivity.IsNetworkingOK())
                {
                    _userDialogs.HideLoading();

                    UIFunctions.ShowErrorForConnectivityMessageToUI();
                    EmailIsEnabled = false;
                    PasswordIsEnabled = false;
                }
                else if (await GetAuthenticatedUser())
                {
                    _userDialogs.HideLoading(); // Escondendo o loading da verificação de Rede.

                    _userDialogs.ShowLoading("Carregando");

                    await _weatherService.GetWeather();

                    RegisterLocalAuthenticatedUser();

                    ; Insights.Identify(App.UserAuthenticated.Email,
                                         Insights.Traits.GuestIdentifier,
                                         App.UserAuthenticated.Email);

                    Tracks.TrackLoginInformation();

                    var tabPage = new FreshMvvm.FreshTabbedNavigationContainer("HomeContainer");
                    tabPage.AddTab<HomePageModel>("Home", Device.OS == TargetPlatform.Android ?
                                                  string.Empty :
                                                  "house-full.png", null);
                    tabPage.AddTab<TravelPageModel>("Itinerário", Device.OS == TargetPlatform.Android ?
                                                    string.Empty :
                                                    "bus-full.png", null);
                    _userDialogs.HideLoading();
                    CoreMethods.SwitchOutRootNavigation("HomeContainer");
                }
                else
                    _userDialogs.HideLoading(); // Escondendo o loading da verificação de Rede.
            }
            catch (Exception ex)
            {
                _userDialogs.HideLoading();

                base.SendToInsights(ex);
                UIFunctions.ShowErrorMessageToUI();
            }
        }

        public async Task<bool> GetAuthenticatedUser() => await _userService.GetAuthenticatedUser();

        public Command Confirm
        {
            get
            {
                return new Command(async (obj) =>
               {
                   try
                   {
                       _userDialogs.ShowLoading("Carregando");

                       // Com token
                       //var userAuthenticated = await _authService.DoAuthentication(Email, Password, false);

                       // Sem token
                       //Gravando user
                       var userAuthenticated = await _userService.Login(Email, Password);

                       if (userAuthenticated)
                       {
                           //Gravando user
                           //await _userService.Login(Email, Password);

                           await _stationService.GetAllStations();
                           await _scheduleService.GetAllSchedules();

                           await InsertTravels();

                           await _weatherService.GetWeather();
                           await _itineraryService.GetAllItineraries();

                           var tabPage = new FreshMvvm.FreshTabbedNavigationContainer("HomeContainer");

                           tabPage.AddTab<HomePageModel>("Home", Device.OS == TargetPlatform.Android ?
                                                        string.Empty :
                                                        "house-full.png", null);

                           tabPage.AddTab<TravelPageModel>("Itinerário", Device.OS == TargetPlatform.Android ?
                                                          string.Empty :
                                                          "bus-full.png", null);

                           RegisterLocalAuthenticatedUser();

                           _userDialogs.HideLoading();
                           CoreMethods.SwitchOutRootNavigation("HomeContainer");
                       }
                       else
                       {
                           _userDialogs.HideLoading();
                           UIFunctions.ShowToastErrorMessageToUI("Usuário/Senha inválidos");
                       }
                   }
                   catch (Exception ex)
                   {
                       _userDialogs.HideLoading();

                       base.SendToInsights(ex);
                       UIFunctions.ShowErrorMessageToUI();
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
    }
}

