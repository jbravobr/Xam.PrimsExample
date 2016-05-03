using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Plugin.Toasts;

namespace IcatuzinhoApp.Droid
{
    [Activity(
        Label = "Icatuzinho",
        Theme = "@style/AppTheme",
        Icon = "@android:color/transparent",
        MainLauncher = true)
    ]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.FormsMaps.Init(this, bundle);
            Xamarin.Insights.Initialize("af422595c1a35c1ad1a77863b9852f80f7d7542c", this);

            DependencyService.Register<ToastNotificatorImplementation>(); // Register your dependency
            ToastNotificatorImplementation.Init(this); // In Android ([this] is the current Android Activity)

            Xamarin.Forms.Forms.Init(this, bundle);

            /*

            Uncomment to remove StatusBar in Android
            
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
            */

            LoadApplication(new App());


#pragma warning disable 618
            // Hiding ActionBar Icon on Android versions using Material Design
            if ((int)Android.OS.Build.VERSION.SdkInt >= 21)
            {
                ActionBar.SetIcon(
                    new ColorDrawable(
                        Resources.GetColor(Android.Resource.Color.Transparent)
                    )
                );
            }
#pragma warning restore 618
        }
    }
}


