using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Plugin.Toasts;
using UIKit;
using Xamarin.Forms;

namespace IcatuzinhoApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            DependencyService.Register<ToastNotificatorImplementation>();
            ToastNotificatorImplementation.Init();
            Xamarin.FormsMaps.Init();
            Xamarin.Insights.Initialize("af422595c1a35c1ad1a77863b9852f80f7d7542c");

            global::Xamarin.Forms.Forms.Init();

            Xamarin.Calabash.Start();

            Appearance.Configure();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

