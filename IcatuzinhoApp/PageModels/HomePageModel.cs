using System;
using PropertyChanged;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;
using UXDivers.Artina.Shared;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class HomePageModel : FreshMvvm.FreshBasePageModel
    {
        public string CurrentDate { get; } = $"{DateTime.Now.Day.ToString()}/{DateTime.Now.Month.ToString()}";

        public string SeatsAvailable { get; set; }

        public string SeatsTotal { get; set; }

        public string Temp { get; set; }

        public string Time { get; set; }

        public string Description { get; set; }

        public bool isCheckIn { get; set; }

        public bool isCheckOut { get; set; }

        const string ZeroHours = "00";
        const string Minutes = "00";

        Travel _travel { get; set; }

        Weather _weather { get; set; }

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

            //_userDialogs.ShowLoading();

            _travel = await GetNextTravel();

            if (_travel != null)
            {
                SeatsAvailable = _travel.Vehicle.SeatsAvailable.ToString();
                SeatsTotal = _travel.Vehicle.SeatsTotal.ToString();
                Description = _travel.Schedule.Message;

                var _hours = _travel.Schedule.StartSchedule.Hour == 0 ? ZeroHours : _travel.Schedule.StartSchedule.Hour.ToString();
                var _minutes = _travel.Schedule.StartSchedule.Minute == 0 ? Minutes : _travel.Schedule.StartSchedule.Minute.ToString();

                Time = $"{_hours}:{_minutes}";

                var weather = await GetWeather();
                Temp = weather.Temp;

                //_userDialogs.HideLoading();
            }
            else
                await _userDialogs.AlertAsync("Houve um erro na aplicação", "Erro", "OK");
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
            var result = await _travelService.GetAvailableSeats(_travel.Id);

            if (result > 0)
                SeatsAvailable = result.ToString();
        }

        public async Task<Travel> GetNextTravel()
        {
            //Expression<Func<Travel, bool>> bySchedule = (x) => x.Schedule.StartSchedule <= DateTime.Now;
            //var travel = await _travelService.GetWithChildrenAsync(bySchedule);
            var travel = await _travelService.GetWithChildrenByIdAsync(1);

            if (travel != null)
                return travel;

            return null;
        }

        public async Task<Weather> GetWeather()
        {
            var weather = await _weatherService.GetWeather();

            if (weather != null)
                return weather;

            return null;
        }

        public FormattedString CustomFormattedTextCurrentDate
        {
            get
            {
                return new FormattedString
                {
                    Spans = {
                                new Span { Text = "\uf073 ", FontFamily = FontAwesome.FontName, FontSize = 16, ForegroundColor = Color.White },
                                new Span { Text = CurrentDate, FontFamily = FontAwesome.FontName, FontSize = 16, ForegroundColor = Color.White}
                            }
                };
            }
        }

        public FormattedString CustomFormattedTextSeats
        {
            get
            {
                return new FormattedString
                {
                    Spans = {
                                new Span { Text = "\uf183 ", FontFamily = FontAwesome.FontName, FontSize = 16, ForegroundColor = Color.White },
                                new Span { Text = SeatsAvailable, FontAttributes=FontAttributes.Bold, FontFamily = FontAwesome.FontName, FontSize = 16, ForegroundColor = Color.White},
                                new Span { Text = "/", ForegroundColor = Color.White },
                                new Span { Text = SeatsTotal, ForegroundColor = Color.White, FontSize = 16 }
                            }
                };
            }
        }

        public FormattedString CustomFormattedTemp
        {
            get
            {
                return new FormattedString
                {
                    Spans = {
                                new Span { Text = SetFontAwesomeForTemp(), FontFamily = FontAwesome.FontName, FontSize = 16, ForegroundColor = Color.White },
                                new Span { Text = Temp, ForegroundColor = Color.White, FontSize = 16 },
                                new Span { Text = "º", ForegroundColor=Color.White, FontSize=16 }
                            }
                };
            }
        }

        public FormattedString CustomFormattedTextTime
        {
            get
            {
                return new FormattedString
                {
                    Spans = {
                                new Span { Text = "\uf017 ", FontFamily = FontAwesome.FontName, FontSize = 48, ForegroundColor = Color.White },
                                new Span { Text = Time, FontAttributes=FontAttributes.Bold, FontSize = 48, ForegroundColor = Color.White},
                            }
                };
            }
        }

        string SetFontAwesomeForTemp()
        {
            Task<Weather> weather = Task.Run(async () =>
            {
                var w = await GetWeather();
                return w;
            });

            var tempDesc = weather.Result.Ico;

            if (tempDesc.Contains("rain") || tempDesc.Contains("thunder"))
                return $"\uf0e9 ";
            else if (tempDesc.Contains("cloudy"))
                return $"\uf073 ";
            else if (tempDesc.Contains("sunny"))
                return $"\uf185 ";
            else
                return $"\uf186 ";
        }
    }
}

