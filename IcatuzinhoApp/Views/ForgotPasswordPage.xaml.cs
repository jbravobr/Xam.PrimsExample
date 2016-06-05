using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace IcatuzinhoApp
{
    public partial class ForgotPasswordPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Device.OS == TargetPlatform.Android)
                Title = "Login";
        }

        public ForgotPasswordPage()
        {
            InitializeComponent();
        }
    }
}

