using System;
using PropertyChanged;
using Acr.UserDialogs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;

namespace IcatuzinhoApp
{
    [ImplementPropertyChanged]
    public class SchedulePageViewModel : BasePageViewModel
    {
        readonly ITravelService _travelService;
        IUserDialogs _userDialogs { get; set; }

        public List<TravelDTO> TravelsDTO { get; set; }
        public List<Travel> Travels { get; set; }
        public bool IsRefreshing { get; set; }

        public SchedulePageViewModel(IScheduleService scheduleService,
                                     ITravelService travelService)
        {
            _travelService = travelService;
            Init();

            IsRefreshing = false;
        }

        public void Init()
        {
            try
            {
                Travels = GetAll();
            }
            catch (Exception ex)
            {
                _userDialogs.HideLoading();
                base.SendToInsights(ex);
                UIFunctions.ShowErrorMessageToUI();
            }
        }

        public List<Travel> GetAll()
        {
            var collection = _travelService.GetAll();

            foreach (var item in collection)
            {
                TravelsDTO.Add(new TravelDTO
                {
                    Driver = item.Driver,
                    Id = item.Id,
                    Schedule = item.Schedule,
                    Vehicle = item.Vehicle
                });
            }

            foreach (var item in TravelsDTO)
            {
                if (TimeSpan.Compare(DateTime.Now.TimeOfDay, item.Schedule.StartSchedule.TimeOfDay) <= 0)
                    SetScheduleAvatar(true, item);
                else
                    SetScheduleAvatar(false, item);

                if (TimeSpan.Compare(DateTime.Now.TimeOfDay, item.Schedule.StartSchedule.TimeOfDay) <= 0 &&
                 item.Vehicle.SeatsAvailable > 0)
                    SetScheduleStatusDescription(true, item);
                else
                    SetScheduleStatusDescription(false, item);
                                        
            }

            return collection;
        }

        public async Task GetUpdatedSeatsAvailableBySchedule()
        {
            if (Travels == null && !Travels.Any())
                return;

            foreach (var item in Travels)
            {
                item.Vehicle.SeatsAvailable = (int)await _travelService.GetSeatsAvailableByTravel(item.Schedule.Id);
            }
        }

        public void ScheduleGetInfoForUI()
        {
            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                Task.Factory.StartNew(() =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await GetUpdatedSeatsAvailableBySchedule();
                        ScheduleGetInfoForUI();
                    });
                });

                return false;
            });
        }

        public Command Refresh
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        IsRefreshing = true;
                        var ids = TravelsDTO.Select(x => x.Id).ToList();

                        foreach (var id in ids)
                        {
                            var availableSeats = await _travelService.GetAvailableSeats(id);

                            TravelsDTO.First(x => x.Id == id).Vehicle.SeatsAvailable = availableSeats;

                            if (TimeSpan.Compare(DateTime.Now.TimeOfDay, Travels.First(x => x.Id == id).Schedule.StartSchedule.TimeOfDay) <= 0)
                                SetScheduleAvatar(true, TravelsDTO.First(x => x.Id == id));
                            else
                                SetScheduleAvatar(false, TravelsDTO.First(x => x.Id == id));

                            if (TimeSpan.Compare(DateTime.Now.TimeOfDay, Travels.First(x => x.Id == id).Schedule.StartSchedule.TimeOfDay) <= 0 &&
                                Travels.First(x => x.Id == id).Vehicle.SeatsAvailable > 0)
                                SetScheduleStatusDescription(true, TravelsDTO.First(x => x.Id == id));
                            else
                                SetScheduleStatusDescription(false, TravelsDTO.First(x => x.Id == id));
                        }
                    }
                    catch (Exception ex)
                    {
                        SendToInsights(ex);
                        UIFunctions.ShowErrorMessageToUI("Erro ao atualizar as viagens, por favor tente novamente");
                    }
                    finally
                    {
                        IsRefreshing = false;
                    }
                });
            }
        }

        void SetScheduleAvatar(bool available, TravelDTO item)
        {
            if (available)
            {
                item.Schedule.StatusAvatar = "online.png";
                return;
            }

            item.Schedule.StatusAvatar = "offline.png";
        }

        void SetScheduleStatusDescription(bool available, TravelDTO item)
        {
            if (available)
            {
                item.Schedule.StatusDescription = "Disponível";
                return;
            }

            item.Schedule.StatusAvatar = "Indisponível";
        }
    }
}

