using System;
using System.Threading.Tasks;

namespace IcatuzinhoApp
{
    public class WeatherService : BaseService<Weather>, IWeatherService
    {
        IHttpAccessService _httpService;
        ILogExceptionService _log;
        IAuthenticationService _auth;
        Utils<Weather> _utils;

        public WeatherService(IHttpAccessService httpService, 
                              ILogExceptionService log,
                              IAuthenticationService auth)
        {
            _httpService = httpService;
            _log = log;
            _auth = auth;
        }

        public async Task GetWeather()
        {
            try
            {
                var token = _auth.Get();

                var clientCaller = _httpService.Init(token?.AccessToken);
                var data = await clientCaller.GetAsync($"{Constants.WeatherServiceAddress}");

                if (data != null && data.IsSuccessStatusCode)
                {
                    _utils = new Utils<Weather>();
                    var weather = await _utils.ConvertSingleObjectFromJson(data.Content);

                    if (weather != null)
                        InsertOrReplaceWithChildren(weather);
                }
            }
            catch (Exception ex)
            {
                _log.SubmitToInsights(ex);
                UIFunctions.ShowErrorMessageToUI();
            }
        }
    }
}

