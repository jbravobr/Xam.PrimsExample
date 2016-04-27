using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IcatuzinhoApp
{
    [XamlCompilation (XamlCompilationOptions.Skip)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            IoCconfiguration.Init();
            MainPage = GetMainPage();
            MainPage.SetValue (NavigationPage.BarTextColorProperty, Color.White);
        }

        public static Page GetMainPage()
        {
            return FreshMvvm.FreshPageModelResolver.ResolvePageModel<HomePageModel>();
        }
    }
}

