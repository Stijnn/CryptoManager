namespace CryptoManager.Bindings
{
    class CoinCell
    {
        public string cellColor { get; set; }
        public string displayId { get; set; }
        public string displayFullName { get; set; }
        public string displayPriceUSD { get; set; }
        public string displayPriceBTC { get; set; }

        public CoinCell(string cellColor, string displayId, string displayFullName, string displayPriceUSD, string displayPriceBTC)
        {
            this.cellColor = cellColor;
            this.displayId = displayId;
            this.displayFullName = displayFullName;
            this.displayPriceUSD = displayPriceUSD;
            this.displayPriceBTC = displayPriceBTC;
        }
    }
}
