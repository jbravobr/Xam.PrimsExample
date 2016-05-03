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
        List<Station> _stations;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var _stationService = FreshMvvm.FreshIOC.Container.Resolve<IStationService>();
            var _userDialogsService = FreshMvvm.FreshIOC.Container.Resolve<IUserDialogs>();

            if (_stationService != null)
            {
                _stations = _stationService.GetAllWithChildren();

                _userDialogsService.ShowLoading();

                if (_stations != null && _stations.Any())
                {
                    foreach (var s in _stations)
                    {
                        var p = new Pin
                        {
                            Label = s.Name,
                            Position = new Position(s.Latitude, s.Longitude),
                            Type = PinType.SearchResult
                        };

                        MapaTravel.Pins.Add(p);
                    }
                }

                MapaTravel.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(_stations.First().Latitude, _stations.First().Longitude), Distance.FromMeters(1000)));

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

