using GiftHubMobileNew.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GiftHubMobileNew
{
	public partial class App : Application
	{
        internal static readonly IGiftCardService GiftCardService = DependencyService.Get<IGiftCardService>();
        public App ()
		{
			InitializeComponent();

			MainPage = new GiftHubMobileNew.MainPage();
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
