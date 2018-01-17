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
	public partial class GiftCardCreatePage : ContentPage
	{
		public GiftCardCreatePage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }
	}
}