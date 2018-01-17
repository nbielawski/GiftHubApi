using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiftHubMobileNew.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
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
                await DisplayAlert("UhOh", "Please enter a username and password.", "K, Bye");
                return;
            }

            // Turn on the "please wait" spinner.
            pleaseWait.IsRunning = true;
            fldUsername.IsEnabled = false;
            fldPassword.IsEnabled = false;
            btnLogin.IsEnabled = false;

            await App.GiftCardService.Login(fldUsername.Text.Trim(), fldPassword.Text)
                .ContinueWith(async (task) =>

                    {
                        var loggedIn = task.Result;

                        // Let them know if login failed.
                        if (!loggedIn)
                        {

                            await DisplayAlert("UhOh", "Login failed.", "K Bye");
                            fldUsername.IsEnabled = true;
                            fldPassword.IsEnabled = true;
                            btnLogin.IsEnabled = true;
                            pleaseWait.IsRunning = false;
                            return;
                        }

                        pleaseWait.IsRunning = false;
                        await Navigation.PushAsync(new GiftCardsPage(), true);

                    }, TaskScheduler.FromCurrentSynchronizationContext());

        }
    }
}







