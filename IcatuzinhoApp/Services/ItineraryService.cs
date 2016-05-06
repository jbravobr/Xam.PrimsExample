﻿using System;
using System.Threading.Tasks;
using System.Linq;

namespace IcatuzinhoApp
{
    public class ItineraryService : BaseService<Itinerary>, IItineraryService
    {
        IHttpAccessService _httpService;
        ILogExceptionService _log;
        IAuthenticationService _auth;
        Utils<Itinerary> _utils;

        public ItineraryService(IHttpAccessService httpService, 
                                ILogExceptionService log,
                                IAuthenticationService auth)
        {
            _httpService = httpService;
            _log = log;
            _auth = auth;
        }

        public async Task GetAllItineraries()
        {
            try
            {
                var token = _auth.Get();

                var clientCaller = _httpService.Init(token?.AccessToken);
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
                _log.SubmitToInsights(ex);
                UIFunctions.ShowErrorMessageToUI();
            }
        }
    }
}

