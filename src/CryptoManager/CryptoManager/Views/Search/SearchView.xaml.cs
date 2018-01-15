﻿using CryptoManager.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CryptoManager.Views.Search
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchView : ContentPage
	{
        private string convertTo = "USD";
        public SearchView()
        {
            InitializeComponent();
            LoadAssets();
            AllowMethodes();
        }

        private void LoadAssets()
        {
            Picker mainCurrency = this.currencyValue;
            foreach (var currency in Core.Container.Currencies.GetNormalCurrencies())
            {
                mainCurrency.Items.Add(currency);
            }
        }

        private void AllowMethodes()
        {
            calcBtn.Clicked += calcBtn_Clicked;
            currencyPicker.Clicked += CurrencyPicker_Clicked;
            cryptoPicker.Clicked += CryptoPicker_Clicked;
        }

        private void CryptoPicker_Clicked(object sender, EventArgs e)
        {
            
        }

        private void CurrencyPicker_Clicked(object sender, EventArgs e)
        {
            currencyValue.Title = "Current : " + currencyValue.SelectedItem.ToString();
            convertTo = currencyValue.SelectedItem.ToString();
        }

        private async void calcBtn_Clicked(object sender, EventArgs e)
        {
            Currency cur = await Core.Worker.GetCurrency("bitcoin",convertTo);
            var result = await DisplayAlert($"{cur.Title}", cur.Price_USD, "OK","Favorite");
            if (result == true) // if it's equal to Ok
            {
                return;
            }
            else
            {
                await DisplayAlert("Title", "Unfortunately this function isn't implemented yet", "OK");
            }
        }
    }
}