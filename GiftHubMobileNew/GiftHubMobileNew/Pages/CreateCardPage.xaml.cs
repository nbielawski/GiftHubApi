using GiftHub.Models;
using GiftHubMobileNew.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiftHubMobileNew.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateCardPage : ContentPage
	{

        public CreateCardPage()
		{           
            InitializeComponent ();
            SetupUi();
            MainPicker.Items.Add("Amazon");
            MainPicker.Items.Add("Home Depot");
            MainPicker.Items.Add("Kroger");           
            MainPicker.Items.Add("Lowes");
            MainPicker.Items.Add("Target");
            MainPicker.Items.Add("Walmart");      
        }


        private async void SetupUi(){
          
        }    

        private void MainPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var fldCompanyName = MainPicker.Items[MainPicker.SelectedIndex];
        }


        private async void BtnSave_OnClicked(object sender, EventArgs e)
        {
            fldProgressMessage.Text = "Saving, one moment...";
            pleaseWait.IsRunning = true;
            panProgress.IsVisible = true;

            // Make the donation.
            await App.GiftCardService.MakeDonationAsync(new GiftCardCreateViewModel()
            {
               
                CompanyName = MainPicker.SelectedItem.ToString(),
                CardNumber = fldCardNumber.Text.Trim(),
                Amount = decimal.Parse(fldAmount.Text.ToString()),
                ExpirationDate = fldExpirationDate.Date,
               AccessNumber = fldAccessNumber.Text != null? int.Parse(fldAccessNumber.Text.ToString()):0         
        }).ContinueWith(async task =>
                {
                    var success = task.Result;
                    if (success)
                    {
                        await DisplayAlert("Great!", "Thnks for your donation.", "No refunds!");
                        await Navigation.PopAsync(true);
                    }
                    else
                    {
                        fldProgressMessage.Text = "";
                        pleaseWait.IsRunning = false;
                        panProgress.IsVisible = false;

                        await DisplayAlert("Bummer", "The note could not be saved. Are you connected?", "Okie Dokie");
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());            
        }       
    }
}