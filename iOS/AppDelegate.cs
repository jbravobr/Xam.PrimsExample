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
            Xamarin.FormsMaps.Init();
            Xamarin.Insights.Initialize("af422595c1a35c1ad1a77863b9852f80f7d7542c");

            DependencyService.Register<ToastNotificatorImplementation>();
            ToastNotificatorImplementation.Init();

            global::Xamarin.Forms.Forms.Init();

            // Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif

            Appearance.Configure();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

