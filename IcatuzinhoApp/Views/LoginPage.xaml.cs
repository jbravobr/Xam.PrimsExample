using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IcatuzinhoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        protected override void OnAppearing()
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            base.OnAppearing();
        }

        public LoginPage()
        {
            InitializeComponent();
        }
    }
}

