﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IcatuzinhoApp
{
    public class ScheduleService : BaseService<Schedule>, IScheduleService
    {
        IHttpAccessService _httpService;
        ILogExceptionService _log;
        IAuthenticationService _auth;
        Utils<List<Schedule>> _utils;

        public ScheduleService(IHttpAccessService httpService,
                               IAuthenticationService auth)
        {
            _httpService = httpService;
            _auth = auth;
        }

        public async Task GetAllSchedules()
        {
            try
            {
                var token = _auth.Get();

                var clientCaller = _httpService.Init(token?.AccessToken);
                var data = await clientCaller.GetAsync($"{Constants.ScheduleServiceAddress}");

                if (data != null && data.IsSuccessStatusCode)
                {
                    _utils = new Utils<List<Schedule>>();
                    var schedules = await _utils.ConvertSingleObjectFromJson(data.Content);

                    if (schedules != null && schedules.Any())
                        InsertOrReplaceAllWithChildren(schedules);
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

