﻿using Xamarin.Forms.Platform.iOS;
using UIKit;

namespace IcatuzinhoApp.iOS
{
	public static class Appearance
	{
		public static UIColor AccentColor = ExportedColors.AccentColor.ToUIColor();
		public static UIColor TextColor = ExportedColors.InverseTextColor.ToUIColor();

		public static void Configure()
		{
			UINavigationBar.Appearance.BarTintColor = AccentColor;
			UINavigationBar.Appearance.TintColor = TextColor;
			UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes {
				ForegroundColor = TextColor,
			};

			UIProgressView.Appearance.ProgressTintColor = AccentColor;

			UISlider.Appearance.MinimumTrackTintColor = AccentColor;
			UISlider.Appearance.MaximumTrackTintColor = AccentColor;
			UISlider.Appearance.ThumbTintColor = AccentColor;

			UISwitch.Appearance.OnTintColor = AccentColor;

			UITableViewHeaderFooterView.Appearance.TintColor = AccentColor;

			UITableView.Appearance.SectionIndexBackgroundColor = AccentColor;
			UITableView.Appearance.SeparatorColor = AccentColor;

			UITextField.Appearance.TintColor = AccentColor;

			UIButton.Appearance.TintColor = AccentColor;
			UIButton.Appearance.SetTitleColor (AccentColor, UIControlState.Normal);

			UITabBar.Appearance.TintColor = AccentColor;
			//UITabBar.Appearance.BarTintColor = AccentColor;
			UITabBar.Appearance.BackgroundImage = new UIImage ();
			UITabBar.Appearance.BackgroundColor = AccentColor;
		}
	}
}