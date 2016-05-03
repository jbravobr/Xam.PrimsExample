using System;
using PropertyChanged;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class HomePageModel : BasePageModel
    {
        public string CurrentDate { get; } = $"{DateTime.Now.Day.ToString()}/{DateTime.Now.Month.ToString()}";

        public string SeatsAvailable { get; set; }

        public string SeatsTotal { get; set; }

        public string Temp { get; set; }

        public string Time { get; set; }

        public string Description { get; set; }

        public bool isCheckIn { get; set; }

        public bool isCheckOut { get; set; }

        public string WeatherFontAwesome { get; set; }

        const string ZeroHours = "00";

        const string Minutes = "00";

        Travel _travel { get; set; }

        public Weather _weather { get; set; }

        readonly ITravelService _travelService;

        readonly IWeatherService _weatherService;

        readonly IUserDialogs _userDialogs;

        public HomePageModel(ITravelService travelService, IWeatherService weatherService, IUserDialogs userDialogs)
        {
            _travelService = travelService;
            _weatherService = weatherService;
            _userDialogs = userDialogs;

            isCheckIn = true;
            isCheckOut = false;
        }

        public async override void Init(object initData)
        {
            base.Init(initData);

            try
            {
                _userDialogs.ShowLoading();
                _travel = GetNextTravel();

                if (_travel != null)
                {
                    SeatsAvailable = _travel.Vehicle.SeatsAvailable.ToString();
                    SeatsTotal = _travel.Vehicle.SeatsTotal.ToString();
                    Description = _travel.Schedule.Message;

                    var _hours = _travel.Schedule.StartSchedule.Hour == 0 ? ZeroHours : _travel.Schedule.StartSchedule.Hour.ToString();
                    var _minutes = _travel.Schedule.StartSchedule.Minute == 0 ? Minutes : _travel.Schedule.StartSchedule.Minute.ToString();

                    Time = $"{_hours}:{_minutes}";

                    _userDialogs.HideLoading();
                }
                else
                {
                    _userDialogs.HideLoading();
                    await _userDialogs.AlertAsync("Houve um erro na aplicação", "Erro", "OK");
                }
            }
            catch (Exception ex)
            {
                base.SendToInsights(ex);
            }
        }

        public Command CheckIn
        {
            get
            {
                return new Command(async (obj) =>
                {
                    if (await _travelService.DoCheckIn(_travel.Schedule.Id, App.UserAuthenticated.Id))
                    {
                        isCheckIn = false;
                        isCheckOut = true;

                        UpdateSeats();
                    }
                });
            }
        }

        public Command CheckOut
        {
            get
            {
                return new Command(async (obj) =>
                {

                    var confirm = await _userDialogs.ConfirmAsync("Deseja realmente desistir da sua viagem?", "CheckOut", "Sim", "Não");

                    if (confirm)
                    {
                        if (await _travelService.DoCheckOut(_travel.Schedule.Id, App.UserAuthenticated.Id))
                        {
                            isCheckIn = true;
                            isCheckOut = false;
                            UpdateSeats();
                        }
                    }
                });
            }
        }

        public async void UpdateSeats()
        {
            _userDialogs.ShowLoading();
            var result = await _travelService.GetAvailableSeats(_travel.Id);

            if (result > 0)
                SeatsAvailable = result.ToString();

            _userDialogs.HideLoading();
        }

        public Travel GetNextTravel()
        {
            //Expression<Func<Travel, bool>> bySchedule = (x) => x.Schedule.StartSchedule <= DateTime.Now;
            //var travel = await _travelService.GetWithChildrenAsync(bySchedule);
            var travel = _travelService.GetWithChildrenById(1);

            if (travel != null)
                return travel;

            return null;
        }

        public void GetWeather()
        {
            var w = _weatherService.Get();
            _weather.Ico = SetFontAwesomeForTemp(w.Ico);
            _weather.Temp = w.Temp;
        }

        #region Label Text

        public string GetCurrentDate
        {
            get
            {
                return $"\uf073 {CurrentDate}";
            }
        }

        public string GetSeats
        {
            get
            {
                return $"\uf183 {SeatsAvailable}/{SeatsTotal}";
            }
        }

        public string GetTemp
        {
            get
            {
                return $"{_weather.Ico} {_weather.Temp}º";
            }
        }

        public string GetTime
        {
            get
            {
                return $"\uf017 {Time}";
            }
        }

        #endregion

        string SetFontAwesomeForTemp(string ico)
        {
            if (ico.Contains("rain") || ico.Contains("thunder"))
                return $"\uf0e9 ";
            else if (ico.Contains("cloudy"))
                return $"\uf073 ";
            else if (ico.Contains("sunny"))
                return $"\uf185 ";
            else
                return $"\uf186 ";
        }
    }
}

