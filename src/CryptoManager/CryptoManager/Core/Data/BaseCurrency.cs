using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoManager.Core.Data
{
    class BaseCurrency
    {
        public string Base { get; set; }
        public string Date { get; set; }
        public string Rates { get; set; }
        public BaseCurrency()
        {
            Base = " ";
            Date = " ";
            Rates = " ";
        }
    }
}
