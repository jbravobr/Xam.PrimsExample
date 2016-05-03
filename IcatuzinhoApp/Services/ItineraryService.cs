using System;
using System.Threading.Tasks;
using System.Linq;

namespace IcatuzinhoApp
{
    public class ItineraryService : BaseService<Itinerary>, IItineraryService
    {
        IHttpAccessService _httpService;
        Utils<Itinerary> _utils;

        public ItineraryService(IHttpAccessService httpService)
        {
            _httpService = httpService;
        }

        public async Task GetAllItineraries()
        {
            try
            {
                var clientCaller = _httpService.Init();
                var data = await clientCaller.GetAsync($"{Constants.ItineraryServiceAddress}");

                if (data != null && data.IsSuccessStatusCode)
                {
                    _utils = new Utils<Itinerary>();
                    var itineraries = await _utils.ConvertCollectionObjectFromJson(data.Content);

                    if (itineraries != null && itineraries.Any())
                        InsertOrReplaceAllWithChildren(itineraries);
                }

            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
            }
        }
    }
}

