using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace IcatuzinhoApp
{
    public class StationService : BaseService<Station>, IStationService
    {
        IHttpAccessService _httpService;
        Utils<List<Station>> _utils;

        public StationService(IHttpAccessService httpService)
        {
            _httpService = httpService;
        }

        public async Task GetAllStations()
        {
            try
            {
                var clientCaller = _httpService.Init();
                var data = await clientCaller.GetAsync($"{Constants.StationServiceAddress}");

                if (data != null && data.IsSuccessStatusCode)
                {
                    _utils = new Utils<List<Station>>();
                    var stations = await _utils.ConvertSingleObjectFromJson(data.Content);

                    if (stations != null && stations.Any())
                        InsertOrReplaceAllWithChildren(stations);
                }

            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
            }
        }
    }
}

