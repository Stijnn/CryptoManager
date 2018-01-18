using CryptoManager.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CryptoManager.Views.Coins
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CoinDetail : ContentPage
	{
        private ToolbarItem refreshButton;
		public CoinDetail(string id)
		{
			InitializeComponent();
            FillDetailsForSelectedId(id);
            refreshButton = new ToolbarItem("Refresh", "refresh.png", new Action(() => { FillDetailsForSelectedId(id); }));
        }

        private async void FillDetailsForSelectedId(string id)
        {
            spinner.IsRunning = true;
            loaderGrid.IsVisible = true;
            mainGrid.IsVisible = false;
            ToolbarItems.Remove(refreshButton);

            Currency curr = await Core.Worker.GetCurrency(id, "USD");

            lblSymbol.Text = curr.Symbol;
            lblId.Text = curr.ID;
            lblTitle.Text = curr.Title;
            lblCMCRank.Text = curr.CMCRank;
            lblPriceUSD.Text = curr.Price_USD;
            lblPriceBTC.Text = curr.Price_BTC;
            lblVolume.Text = curr.Volume;
            lblMCUsd.Text = curr.MCUsd;
            lblAvailable.Text = curr.Available;
            lblTotal.Text = curr.Total;
            lblMax.Text = curr.Max;
            lblPercChangeHour.Text = curr.PercChangeHour;
            lblPerChangeDay.Text = curr.PercChangeDay;
            lblPerChangeWeek.Text = curr.PercChangeWeek;
            lblLastUpdate.Text = curr.LastUpdate;

            spinner.IsRunning = false;
            loaderGrid.IsVisible = false;
            mainGrid.IsVisible = true;

            if (!ToolbarItems.Contains(refreshButton))
                ToolbarItems.Add(refreshButton);
        }
	}
}