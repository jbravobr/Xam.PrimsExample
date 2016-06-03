using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using IcatuzinhoApp.iOS;
using IcatuzinhoApp;
using UIKit;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationRenderer))]
namespace IcatuzinhoApp.iOS
{
    public class CustomNavigationRenderer : NavigationRenderer
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.NavigationBar.BarTintColor = UIColor.FromRGB(132, 136, 139);
        }
    }
}

