using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IcatuzinhoApp
{
    public partial class RegisterPage : ContentPage
    {
        protected override void OnAppearing()
        {
            //NavigationPage.SetBackButtonTitle(this, "");
            base.OnAppearing();
        }

        public RegisterPage()
        {
            InitializeComponent();
        }
    }
}

