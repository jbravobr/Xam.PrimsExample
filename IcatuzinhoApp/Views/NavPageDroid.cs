using System;
using Xamarin.Forms;

namespace IcatuzinhoApp
{
    public class NavPageDroid : NavigationPage
    {
        public NavPageDroid(Page root)
            : base(new LoginPage())
        {
        }
    }
}

