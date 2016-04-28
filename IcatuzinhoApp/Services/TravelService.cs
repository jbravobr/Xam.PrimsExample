using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IcatuzinhoApp
{
    public class TravelService : BaseService<Travel>, ITravelService
    {
        IHttpAccessService _httpService;
        Utils<Travel> _utils;

        public TravelService(IHttpAccessService httpService)
        {
            _httpService = httpService;
        }

        public async Task GetTravelById(int travelId)
        {
            try
            {
                var clientCaller = _httpService.Init();
                var data = await clientCaller.GetAsync($"{Constants.TravelServiceAddress}{travelId}");

                if (data != null && data.IsSuccessStatusCode)
                {
                    _utils = new Utils<Travel>();
                    var travel = await _utils.ConvertSingleObjectFromJson(data.Content);

                    if (travel != null)
                        await base.InsertOrReplaceWithChildrenAsync(travel);
                }

            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
            }
        }

        public async Task<bool> DoCheckIn(int scheduleId, int userId)
        {
            try
            {
                var clientCaller = _httpService.Init();
                var data = await clientCaller.GetAsync($"{Constants.TravelServiceCheckInAddress}{scheduleId}/{userId}");

                if (data != null && data.IsSuccessStatusCode)
                {
                    _utils = new Utils<Travel>();
                    var result = await _utils.ConvertSingleObjectFromJsonToBolean(data.Content);

                    return await Task.FromResult(result);
                }

                return await Task.FromResult(false);
            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DoCheckOut(int scheduleId, int userId)
        {
            try
            {
                var clientCaller = _httpService.Init();
                var data = await clientCaller.GetAsync($"{Constants.TravelServiceCheckOutAddress}{scheduleId}/{userId}");

                if (data != null && data.IsSuccessStatusCode)
                {
                    _utils = new Utils<Travel>();
                    var result = await _utils.ConvertSingleObjectFromJsonToBolean(data.Content);

                    return await Task.FromResult(result);
                }

                return await Task.FromResult(false);
            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
                return await Task.FromResult(false);
            }
        }
    }
}

