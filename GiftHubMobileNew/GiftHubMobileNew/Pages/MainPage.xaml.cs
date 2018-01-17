using GiftHubMobileNew.Pages;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiftHubMobileNew
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }

        private async void BtnLogin_OnClicked(object sender, EventArgs e)
        {
            // Make sure they filled all the fields.
            if (string.IsNullOrWhiteSpace(fldUsername.Text) || string.IsNullOrWhiteSpace(fldPassword.Text))
            {
                await DisplayAlert("Uhoh", "Please enter a username and password.", "K, Bye");
                return;
            }

            // Turn on the "please wait" spinner.
            pleaseWait.IsRunning = true;
            fldUsername.IsEnabled = false;
            fldPassword.IsEnabled = false;
            btnLogin.IsEnabled = false;

            // Attempt to log in.
            await App.GiftCardService.Login(fldUsername.Text.Trim(), fldPassword.Text)
                .ContinueWith(async (task) =>
                {
                    // Get the result.
                    var loggedIn = task.Result;

                    // Let them know if login failed.
                    if (!loggedIn)
                    {
                        await DisplayAlert("Oops", "Login failed.", "K, Bye");
                        fldUsername.IsEnabled = true;
                        fldPassword.IsEnabled = true;
                        btnLogin.IsEnabled = true;
                        pleaseWait.IsRunning = false;
                        return;
                    }

                    // If login was successful, send them to the make a donation page.
                    pleaseWait.IsRunning = false;
                    await Navigation.PushAsync(new GiftCardCreatePage(), true);

                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

    }
}
