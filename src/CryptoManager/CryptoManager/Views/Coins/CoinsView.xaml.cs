using CryptoManager.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CryptoManager.Views.Coins
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CoinsView : ContentPage
	{
		public CoinsView ()
		{
			InitializeComponent();
            AllowMethodes();
            LoadCoins();
		}

        private void AllowMethodes()
        {
            listCoins.ItemTapped += listCoins_ItemTapped;
        }

        private async void LoadCoins()
        {
            spinner.IsRunning = true;
            spinner.IsVisible = true;
            List<Bindings.CoinCell> source = new List<Bindings.CoinCell>();
            string[] currencies = new string[]
            {
                "bitcoin", "ethereum", "ripple", "verge", "dash", "litecoin", "stellar", "monero", "bytecoin-bcn", "zcash", "stratis", "dogecoin", "status", "ardor", "cardano", "nem", "iota"
            };
            Array.Sort(currencies);

            string[] cols = { "#212121", "#444444" };
            int swCol = 0;
            for (int i = 0; i < currencies.Length; i++)
            {
                if (swCol == 0)
                    swCol = 1;
                else
                    swCol = 0;

                Currency curr = await Core.Worker.GetCurrency(currencies[i], "USD");
                source.Add(new Bindings.CoinCell(cols[swCol], curr.Symbol, curr.Title, $"${curr.Price_USD}", $"{curr.Price_BTC} BTC" ));
            }
            listCoins.ItemsSource = source;
            spinner.IsRunning = false;
            spinner.IsVisible = false;
        }

        private void listCoins_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            // do something

            ((ListView)sender).SelectedItem = null;          
        }
    }
}