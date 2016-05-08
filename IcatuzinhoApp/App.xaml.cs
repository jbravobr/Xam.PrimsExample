using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin;

namespace IcatuzinhoApp
{
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class App : Application
    {
        public static User UserAuthenticated { get; set; }

        public App()
        {
            try
            {
                InitializeComponent();

                IoCconfiguration.Init();

                MainPage = GetMainPage();
                MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
            }
            catch (Exception ex)
            {
                Insights.Report(ex);
            }
        }

        public static Page GetMainPage() => FreshMvvm.FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
    }
}