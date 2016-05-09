using System;
using PropertyChanged;
using Acr.UserDialogs;
using Xamarin.Forms;
using System.Collections.Generic;


namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class SchedulePageModel : BasePageModel
    {
        readonly IScheduleService _scheduleService;
        readonly IUserDialogs _userDialogs;

        public IList<Schedule> Schedules { get; set; }

        public SchedulePageModel(IScheduleService scheduleService,
                                 IUserDialogs userDialogs)
        {
            _scheduleService = scheduleService;
            _userDialogs = userDialogs;
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            try
            {
                _userDialogs.ShowLoading("Carregando");

                Schedules = GetAll();

                _userDialogs.HideLoading();
            }
            catch (Exception ex)
            {
                _userDialogs.HideLoading();
                base.SendToInsights(ex);
                UIFunctions.ShowErrorMessageToUI();
            }
        }

        public IList<Schedule> GetAll()
        {
            return _scheduleService.GetAll();
        }
    }
}

