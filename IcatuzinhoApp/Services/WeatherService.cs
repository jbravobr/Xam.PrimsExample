using System;
using System.Threading.Tasks;

namespace IcatuzinhoApp
{
    public class WeatherService : BaseService<Weather>, IWeatherService
    {
        IHttpAccessService _httpService;
        Utils<Weather> _utils;

        public WeatherService(IHttpAccessService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Weather> GetWeather()
        {
            try
            {
                var clientCaller = _httpService.Init();
                var data = await clientCaller.GetAsync($"{Constants.WeatherServiceAddress}");

                if (data != null && data.IsSuccessStatusCode)
                {
                    _utils = new Utils<Weather>();
                    var weather = await _utils.ConvertSingleObjectFromJson(data.Content);

                    if (weather != null)
                        return weather;
                }

                return null;
            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
                return null;
            }
        }
    }
}

