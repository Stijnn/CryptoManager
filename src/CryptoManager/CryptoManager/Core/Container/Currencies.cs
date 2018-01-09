using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoManager.Core.Container
{
    class Currencies
    {
        public static List<string> GetNormalCurrencies()
        {
            return new List<string>
            {
                "AUD", "BRL", "CAD", "CHF", "CLP", "CNY", "CZK", "DKK", "EUR", "GBP", "HKD", "HUF", "IDR", "ILS", "INR", "JPY", "KRW", "MXN", "MYR", "NOK", "NZD", "PHP", "PKR", "PLN", "RUB", "SEK", "SGD", "THB", "TRY", "TWD", "ZAR"
            };
        }
    }
}
