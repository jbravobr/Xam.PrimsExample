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
            //DependencyService.Register<ToastNotificatorImplementation>();
            //ToastNotificatorImplementation.Init();
            Xamarin.FormsMaps.Init();

#if DEBUG
            Xamarin.Insights.Initialize(Xamarin.Insights.DebugModeKey);
#else
            Xamarin.Insights.Initialize("af73d7945c2d65a46435cb2f6441453f416e9b43");
#endif

            global::Xamarin.Forms.Forms.Init();

            Xamarin.Calabash.Start();

            Appearance.Configure();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

