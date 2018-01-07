using CryptoManager.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CryptoManager.Views.Search
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchView : ContentPage
	{
		public SearchView ()
		{
			InitializeComponent (); AllowDelegates();
        }

        private void AllowDelegates()
        {
            Button Btn = this.FindByName<Button>("btn");
            Btn.Clicked += Btn_Clicked;
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            Currency cur = await Core.Worker.GetCurrency("bitcoin");
            await DisplayAlert("Title", cur.Price_USD, "Cancel");
        }
    }
}