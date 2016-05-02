using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace IcatuzinhoApp
{
    public partial class TravelPage : ContentPage
    {
        double _latitude = -22.9101457;
        double _longitude = -43.1707052;
        List<Station> Stations;


        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var _stationService = FreshMvvm.FreshIOC.Container.Resolve<IStationService>();
            var _userDialogsService = FreshMvvm.FreshIOC.Container.Resolve<IUserDialogs>();

            if (_stationService != null)
            {
                Stations = await _stationService.GetAllWithChildrenAsync();

                _userDialogsService.ShowLoading();

                if (Stations != null && Stations.Any())
                {
                    foreach (var station in Stations)
                    {
                        var p = new Pin
                        {
                            Label = station.Name,
                            Position = new Position(station.Latitude, station.Longitude),
                            Type = PinType.SearchResult
                        };

                        MapaTravel.Pins.Add(p);
                    }
                }

                MapaTravel.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(Stations.First().Latitude, Stations.First().Longitude), Distance.FromMeters(1000)));

                _userDialogsService.HideLoading();
            }
        }

        public TravelPage()
        {
            InitializeComponent();

            try
            {
                MapaTravel.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(_latitude, _longitude), new Distance(2.00)));
            }
            catch (Exception ex)
            {
                new LogExceptionService().SubmitToInsights(ex);
            }
        }
    }
}

