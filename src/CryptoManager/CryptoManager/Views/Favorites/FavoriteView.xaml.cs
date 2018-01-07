using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoManager.Core.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CryptoManager.Views.Favorites
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavoriteView : ContentPage
	{
		public FavoriteView()
		{
			InitializeComponent();
            AllowDelegates();
        }

        private void AllowDelegates()
        {
            Button Btn = this.FindByName<Button>("btn");
            Btn.Clicked += Btn_Clicked;
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            Currency cur = await Core.Worker.GetCurrency("bitcoin");
        }
    }
}