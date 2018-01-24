using GiftHubMobileNew.Contracts;
using GiftHubMobileNew.Pages;
using GiftHubMobileNew.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: Xamarin.Forms.Dependency(typeof(GiftCardService))]
namespace GiftHubMobileNew
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
	{
        internal static readonly IGiftCardService GiftCardService = DependencyService.Get<IGiftCardService>();
        public App ()
		{
			InitializeComponent();

            this.MainPage = new NavigationPage(new LoginPage());
            
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
