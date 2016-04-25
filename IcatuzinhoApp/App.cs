using System;

using Xamarin.Forms;
using Autofac;

namespace IcatuzinhoApp
{
	public class App : Application
	{
		public static IContainer Container { get; set; }

		public App ()
		{
			// Inicializando Container para Injeção de Dependência.
			App.Container = AutoFacConfig.Init ();

			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

