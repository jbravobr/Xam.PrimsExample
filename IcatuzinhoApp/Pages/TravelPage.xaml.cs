using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace IcatuzinhoApp
{
    public partial class TravelPage : ContentPage
    {
        double _latitude = -22.9101457;
        double _longitude = -43.1707052;

        public TravelPage()
        {
            InitializeComponent();
            this.MapRoutes.MapType = Xamarin.Forms.Maps.MapType.Street;

            try
            {
                this.MapRoutes.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(_latitude, _longitude), new Distance(0.50)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

