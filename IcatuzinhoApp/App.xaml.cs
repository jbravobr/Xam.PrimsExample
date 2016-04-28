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

            MainPage = GetMainPage();

            var page = new FreshMvvm.FreshTabbedNavigationContainer();
            page.AddTab<HomePageModel>("Home", "monkeyicon.png", null);
            page.AddTab<TravelPageModel>("Itinerário", "monkeyicon.png", null);

            //MainPage = page;

            MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
        }

        public static Page GetMainPage()
        {
            return FreshMvvm.FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
        }
    }
}