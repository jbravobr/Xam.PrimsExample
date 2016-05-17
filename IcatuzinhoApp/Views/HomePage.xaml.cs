
using Xamarin.Forms;

namespace IcatuzinhoApp
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            var model = BindingContext as HomePageViewModel;

            if (Device.OS == TargetPlatform.Android)
            {
                this.ToolbarItems.Add(new ToolbarItem
                {
                    Text = "Sair",
                    Priority = 0,
                    Command = model.ShowMenuMore,
                    Order = ToolbarItemOrder.Secondary
                });
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                this.ToolbarItems.Add(new ToolbarItem
                {
                    Icon = "more-ios.png",
                    Command = model.ShowMenuMore,
                    Order = ToolbarItemOrder.Primary
                });
            }
        }
    }
}

