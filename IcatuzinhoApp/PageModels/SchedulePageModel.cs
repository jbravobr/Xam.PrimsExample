using System;
using System.Collections.ObjectModel;
using PropertyChanged;
using Acr.UserDialogs;
using Xamarin.Forms;


namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class SchedulePageModel : BasePageModel
    {
        readonly IScheduleService _scheduleService;
        readonly IUserDialogs _userDialogs;

        public ObservableCollection<Schedule> Schedules { get; set; }

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

        public ObservableCollection<Schedule> GetAll()
        {
            return new ObservableCollection<Schedule>(_scheduleService.GetAll());
        }
    }
}

