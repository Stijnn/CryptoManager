using CryptoManager.Core.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Widget;

using ListView = Xamarin.Forms.ListView;


namespace CryptoManager.Views.Coins
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CoinsView : ContentPage
	{
        private ToolbarItem refreshButton;
        private ToolbarItem infoButton;

        private List<Bindings.CoinCell> items;
        private List<Bindings.CoinCell> lastItems;

        public CoinsView ()
		{
			InitializeComponent ();
            AllowMethodes();
            LoadCoins();

            refreshButton = new ToolbarItem("Refresh", "refresh.png", new Action(() => { LoadCoins(); }));
            infoButton = new ToolbarItem("Last synctime", "info.png", new Action(async() => {
                Toast.MakeText(Android.App.Application.Context, "Last synced: " + await Files.FileDependency.GetSingleJsonValue<string>("settings.json", "lastSyncDate"), ToastLength.Short).Show();
            }));

            txtSearch.SearchButtonPressed += SearchCoins;
            txtSearch.TextChanged += SearchCoins;
            SizeChanged += (sender, args) =>
            {
                if (Width > Height)
                {
                    heightDefTop.Height = new GridLength(1, GridUnitType.Star);
                    heightDefBottom.Height = new GridLength(9, GridUnitType.Star);
                }
                else
                {
                    heightDefTop.Height = new GridLength(0.5, GridUnitType.Star);
                    heightDefBottom.Height = new GridLength(9.5, GridUnitType.Star);
                }
            };
        }        

        private void AllowMethodes()
        {
            listCoins.ItemTapped += listCoins_ItemTapped;
        }

        private async void LoadCoins()
        {
            spinner.IsRunning = true;
            loaderGrid.IsVisible = true;
            mainGrid.IsVisible = false;
            searchGrid.IsVisible = false;
            ToolbarItems.Remove(infoButton);
            ToolbarItems.Remove(refreshButton);

            List<Bindings.CoinCell> source = new List<Bindings.CoinCell>();

            string target = await Core.Fetcher.TargetLoad();
            statusText.Text = $"Loading { target.ToLower() } data...";
            JArray results = await Core.Fetcher.FetchCoinData();
            List<Currency> curList = new List<Currency>();

            int count = 0;
            foreach (JObject obj in results)
            {
                try
                {
                    count++;
                    Currency curr = new Currency();
                    curr.ID = obj.GetValue("id").ToString();
                    curr.Title = obj.GetValue("name").ToString();
                    curr.Symbol = obj.GetValue("symbol").ToString();
                    curr.CMCRank = obj.GetValue("rank").ToString();
                    curr.Price_USD = obj.GetValue("price_usd").ToString();
                    curr.Price_BTC = obj.GetValue("price_btc").ToString();
                    curr.Volume = obj.GetValue("24h_volume_usd").ToString();
                    curr.MCUsd = obj.GetValue("market_cap_usd").ToString();
                    curr.Available = obj.GetValue("available_supply").ToString();
                    curr.Total = obj.GetValue("total_supply").ToString();
                    curr.Max = obj.GetValue("max_supply").ToString();
                    curr.PercChangeHour = obj.GetValue("percent_change_1h").ToString();
                    curr.PercChangeDay = obj.GetValue("percent_change_24h").ToString();
                    curr.PercChangeWeek = obj.GetValue("percent_change_7d").ToString();
                    curr.LastUpdate = Epoch.Timestamp(obj.GetValue("last_updated").ToString());
                    curList.Add(curr);
                }
                catch (Exception e)
                {

                }
            }
            Currency[] temp = curList.ToArray();
            Array.Sort(curList.Select(x => x.ID).ToArray(), temp);
            curList = temp.ToList();

            string[] cols = { "#212121", "#444444" };
            int swCol = 0;
            for (int i = 0; i < curList.Count; i++)
            {
                if (swCol == 0)
                    swCol = 1;
                else
                    swCol = 0;

                source.Add(new Bindings.CoinCell(cols[swCol], curList[i].Symbol, curList[i].ID, curList[i].Title, $"${curList[i].Price_USD}", $"{curList[i].Price_BTC} BTC"));
            }
            listCoins.ItemsSource = source;
            items = source;
            lastItems = source;
            spinner.IsRunning = false;
            loaderGrid.IsVisible = false;
            mainGrid.IsVisible = true;
            searchGrid.IsVisible = true;

            if (!ToolbarItems.Contains(infoButton))
                ToolbarItems.Add(infoButton);
            if (!ToolbarItems.Contains(refreshButton))
                ToolbarItems.Add(refreshButton);            
        }

        private void listCoins_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            Navigation.PushAsync(new CoinDetail(((sender as ListView).SelectedItem as Bindings.CoinCell).displayId));
            ((ListView)sender).SelectedItem = null;
        }

        private void SearchCoins(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                List<Bindings.CoinCell> buffer = new List<Bindings.CoinCell>();

                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].displayFullName != null)
                        if (items[i].displayFullName.ToLower().Contains(txtSearch.Text.Trim().ToLower()))
                        {
                            buffer.Add(items[i]);
                        }
                }

                if (buffer.Count > 0)
                {
                    string[] cols = { "#212121", "#444444" };
                    List<Bindings.CoinCell> source = new List<Bindings.CoinCell>();

                    int swCol = 0;
                    for (int i = 0; i < buffer.Count; i++)
                    {
                        if (swCol == 0)
                            swCol = 1;
                        else
                            swCol = 0;

                        source.Add(new Bindings.CoinCell(cols[swCol], buffer[i].displaySymbol, buffer[i].displayId, buffer[i].displayFullName, $"{buffer[i].displayPriceUSD}", $"{buffer[i].displayPriceBTC}"));
                    }
                    listCoins.ItemsSource = source;
                    lastItems = source;
                }
                else
                {
                    listCoins.ItemsSource = null;
                }
            }
            else
                listCoins.ItemsSource = items;
        }
    }
}