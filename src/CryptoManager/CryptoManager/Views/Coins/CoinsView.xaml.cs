﻿using CryptoManager.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;

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
            JArray results = await Service.getData("https://api.coinmarketcap.com/v1/ticker/?limit=0");
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

                source.Add(new Bindings.CoinCell(cols[swCol], curList[i].Symbol, curList[i].ID, curList[i].Title, $"${curList[i].Price_USD}", $"{curList[i].Price_BTC} BTC" ));
            }
            listCoins.ItemsSource = source;
            spinner.IsRunning = false;
            spinner.IsVisible = false;
        }

        private void listCoins_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            Navigation.PushAsync(new CoinDetail(((sender as ListView).SelectedItem as Bindings.CoinCell).displayId));
            ((ListView)sender).SelectedItem = null;          
        }
    }
}