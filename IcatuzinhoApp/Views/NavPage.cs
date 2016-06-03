using System;

using Xamarin.Forms;

namespace IcatuzinhoApp
{
    public class NavPage : CustomNavigationPage
    {
        public NavPage() : base(new LoginPage())
        {
            Title = "";
        }
    }
}


