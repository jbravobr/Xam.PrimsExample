using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IcatuzinhoApp
{
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            IoCconfiguration.Init();

            var page = new FreshMvvm.FreshTabbedNavigationContainer();
            page.AddTab<HomePageModel>("Home", "");
            page.AddTab<TravelPageModel>("Itinerário", "");

            MainPage = page;
            MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
        }

        public static Page GetMainPage()
        {
            return FreshMvvm.FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
        }
    }
}

