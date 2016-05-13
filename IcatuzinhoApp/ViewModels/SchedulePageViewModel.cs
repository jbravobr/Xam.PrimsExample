using System;
using PropertyChanged;
using Acr.UserDialogs;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class SchedulePageViewModel : BasePageViewModel
    {
        readonly IScheduleService _scheduleService;
        readonly ITravelService _travelService;
        IUserDialogs _userDialogs { get; set; }

        public IList<Schedule> Schedules { get; set; }

        public SchedulePageViewModel(IScheduleService scheduleService,
                                     ITravelService travelService)
        {
            _scheduleService = scheduleService;
            _travelService = travelService;
        }

        protected async override void Init()
        {
            try
            {
                _userDialogs = App._container.Resolve<IUserDialogs>();
                _userDialogs.ShowLoading("Carregando");

                Schedules = await GetAll();

                _userDialogs.HideLoading();
            }
            catch (Exception ex)
            {
                _userDialogs.HideLoading();
                base.SendToInsights(ex);
                UIFunctions.ShowErrorMessageToUI();
            }

            base.Init();
        }

        public async Task<IList<Schedule>> GetAll()
        {
            var collection = _scheduleService.GetAll();

            foreach (var item in collection)
            {
                Expression<Func<Travel, bool>> byTravelId = (t) => t.ScheduleId == item.Id;
                var travel = _travelService.GetWithChildren(byTravelId);
                var seatsAvailabe = await _travelService.GetAvailableSeats(travel.Id);

                item.TimeSchedule = Convert.ToDateTime(item.StartSchedule);

                item.StatusAvatar = DateTime.Now.Hour <= item.TimeSchedule.Hour ?
                                    SetScheduleAvailable(true) :
                                    SetScheduleAvailable(false);

                item.StatusDescription = DateTime.Now.Hour < item.TimeSchedule.Hour &&
                                         seatsAvailabe > 0 ?
                                        "Disponível" :
                                        "Indisponível";
            }

            return collection;
        }

        string SetScheduleAvailable(bool available)
        {
            return available ? "online.png" : "offline.png";
        }
    }
}

