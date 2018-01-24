using GiftHub.Models;
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
	public partial class GiftCardsPage : ContentPage
	{
        private List<GiftCardViewModel> Cards { get; set; }

		public GiftCardsPage ()
		{
			InitializeComponent ();
            SetupUI();           
		}

        private void SetupUI()
        {            
            // Wire up refreshing.
            lvwCards.IsPullToRefreshEnabled = true;
            lvwCards.Refreshing += async (o, args) =>
            {
                await PopulateCardsList();
                lvwCards.IsRefreshing = false;
                lblNoCards.IsVisible = !Cards.Any();
            };

            // Add "New Note" icon to title bar.
            this.ToolbarItems.Add(new ToolbarItem("Make Donation", null, async () =>
            {
                await Navigation.PushAsync(new CreateCardPage());
            }));

            this.ToolbarItems.Add(new ToolbarItem("Log Out", null, async () =>
            {
                if (await DisplayAlert("Well?", "Are you sure you want to quit back to the login screen?", "Yep", "Nope"))
                {
                    await Navigation.PushAsync(new LoginPage(),true);
                }
            }));
        }


            private async Task PopulateCardsList()
            {
                await App
                    .GiftCardService
                    .GetAll()
                    .ContinueWith(task =>
                    {
                        var cards = task.Result;

                        Cards = cards
                            .OrderByDescending(card => card.DonationUtc) 
                            .Select(g => new GiftCardViewModel
                            {
                               CompanyName = g.CompanyName,
                               Amount = g.Amount,
                               DonationUtc = g.DonationUtc                               
                            })
                            .ToList();

                        lvwCards.ItemsSource = Cards;

                    // Clear any item selection.
                    lvwCards.SelectedItem = null;

                    }, TaskScheduler.FromCurrentSynchronizationContext());
            }



        protected override async void OnAppearing()
        {
            await PopulateCardsList();            
        }

        private void LvwCards_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var card = e.SelectedItem as GiftCardViewModel;
            }
        }

    }
}