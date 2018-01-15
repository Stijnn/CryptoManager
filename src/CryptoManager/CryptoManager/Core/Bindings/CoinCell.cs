namespace CryptoManager.Bindings
{
    public class CoinCell
    {
        public string cellColor { get; set; }
        public string displaySymbol { get; set; }
        public string displayId { get; set; }
        public string displayFullName { get; set; }
        public string displayPriceUSD { get; set; }
        public string displayPriceBTC { get; set; }

        public CoinCell(string cellColor, string displaySymbol, string displayId, string displayFullName, string displayPriceUSD, string displayPriceBTC)
        {
            this.cellColor = cellColor;
            this.displaySymbol = displaySymbol;
            this.displayId = displayId;
            this.displayFullName = displayFullName;
            this.displayPriceUSD = displayPriceUSD;
            this.displayPriceBTC = displayPriceBTC;
        }
    }
}
