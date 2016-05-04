using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq;
using Acr.UserDialogs;

namespace IcatuzinhoApp
{
    public partial class TravelPage : ContentPage
    {
        double _latitudeInicial = -22.9101457;
        double _longitudeInicial = -43.1707052;

        List<Station> _stations;
        ILogExceptionService _logExceptionService;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var _userDialogsService = FreshMvvm.FreshIOC.Container.Resolve<IUserDialogs>();

            try
            {
                CustomMap iosMap;

                if (Device.OS == TargetPlatform.iOS)
                    iosMap = new CustomMap();

                var model = BindingContext as TravelPageModel;
                var routes = model.Get();

                var _stationService = FreshMvvm.FreshIOC.Container.Resolve<IStationService>();

                if (_logExceptionService == null)
                    _logExceptionService = FreshMvvm.FreshIOC.Container.Resolve<ILogExceptionService>();

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

                        if (routes != null && routes.Any())
                        {
                            foreach (var route in routes.OrderBy(c => c.Order))
                            {
                                MapaTravel.RouteCoordinates.Add(new Position(route.Latitude, route.Longitude));
                            }
                        }
                    }

                    MapaTravel.MoveToRegion(MapSpan.FromCenterAndRadius(
                        new Position(_stations.First().Latitude,
                                     _stations.First().Longitude),
                                Distance.FromMeters(1000)));

                    _userDialogsService.HideLoading();

                    if (Device.OS == TargetPlatform.iOS)
                    {
                        iosMap = MapaTravel;
                        Content = new StackLayout
                        {
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            Padding = 0,
                            Children = {
                                        iosMap
                            }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                _logExceptionService.SubmitToInsights(ex);
                _userDialogsService.HideLoading();
            }
        }

        public TravelPage()
        {
            InitializeComponent();

            if (_logExceptionService == null)
                _logExceptionService = FreshMvvm.FreshIOC.Container.Resolve<ILogExceptionService>();

            try
            {
                MapaTravel.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(_latitudeInicial, _longitudeInicial), new Distance(2.00)));
            }
            catch (Exception ex)
            {
                _logExceptionService.SubmitToInsights(ex);
            }
        }
    }
}

