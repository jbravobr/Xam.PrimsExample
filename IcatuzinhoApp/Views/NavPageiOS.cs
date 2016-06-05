using System;

using Xamarin.Forms;

namespace IcatuzinhoApp
{
    public class NavPageiOS : CustomNavigationPage
    {
        public NavPageiOS(Page root)
            : base(new LoginPage())
        {
            
        }
    }
}


