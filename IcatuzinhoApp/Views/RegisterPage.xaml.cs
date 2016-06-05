using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IcatuzinhoApp
{
    public partial class RegisterPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Device.OS == TargetPlatform.Android)
                Title = "Login";
        }

        public RegisterPage()
        {
            InitializeComponent();
        }
    }
}

