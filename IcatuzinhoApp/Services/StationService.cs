﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace IcatuzinhoApp
{
    public class StationService : BaseService<Station>, IStationService
    {
        IHttpAccessService _httpService;
        ILogExceptionService _log;
        IAuthenticationService _auth;
        Utils<List<Station>> _utils;

        public StationService(IHttpAccessService httpService, 
                              ILogExceptionService log,
                              IAuthenticationService auth)
        {
            _httpService = httpService;
            _log = log;
            _auth = auth;
        }

        public async Task GetAllStations()
        {
            try
            {
                var token = _auth.Get();

                var clientCaller = _httpService.Init(token?.AccessToken);
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
                _log.SubmitToInsights(ex);
                UIFunctions.ShowErrorMessageToUI();
            }
        }
    }
}

