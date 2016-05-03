using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IcatuzinhoApp
{
    public class ScheduleService : BaseService<Schedule>, IScheduleService
    {
        IHttpAccessService _httpService;
        Utils<List<Schedule>> _utils;

        public ScheduleService(IHttpAccessService httpService)
        {
            _httpService = httpService;
        }

        public async Task GetAllSchedules()
        {
            try
            {
                var clientCaller = _httpService.Init();
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
                new LogExceptionService().SubmitToInsights(ex);
            }
        }
    }
}

