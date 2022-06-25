namespace LuccaDevises.Types
{
    /// <summary>
    /// Un taux de change
    /// </summary>
    public readonly struct ExchangeRate
    {
        /// <summary>
        /// La devise de départ
        /// </summary>
        public Currency From { get; }

        /// <summary>
        /// La devise cible
        /// </summary>
        public Currency To { get; }

        /// <summary>
        /// Le taux de change vers la devise cible depuis la devise de départ
        /// </summary>
        public Rate Rate { get; }

        /// <summary>
        /// Initialise un nouveau taux de change
        /// </summary>
        /// <param name="from">La devise de départ</param>
        /// <param name="to">La devise cible</param>
        /// <param name="rate">Le taux de conversion</param>
        public ExchangeRate(Currency from, Currency to, Rate rate)
        {
            From = from;
            To = to;
            Rate = rate;
        }

        /// <summary>
        /// Initialise un nouveau taux de change
        /// </summary>
        /// <param name="fromCurrencyIsoCode">La chaine ISO de la devise de départ</param>
        /// <param name="to">La chaine ISO de la devise cible</param>
        /// <param name="rate">Le taux de conversion</param>
        public ExchangeRate(string fromCurrencyIsoCode, string toCurrencyIsoCode, decimal rate)
        {
            From = new Currency(fromCurrencyIsoCode);
            To = new Currency(toCurrencyIsoCode);
            Rate = new Rate(rate);
        }

        /// <summary>
        /// Indique si le taux change peut convertir depuis une des deux devises vers l'autre devise
        /// </summary>
        /// <param name="c1">Le première devise</param>
        /// <param name="c2">La deuxième devise</param>
        /// <returns>Vrai si le taux change peut convertir depuis une des deux devises vers l'autre devise</returns>
        public bool CanConvert(Currency c1, Currency c2)
        {
            return (From == c1 && To == c2) || (From == c2 && To == c1);
        }

        /// <summary>
        /// Converti un montant
        /// </summary>
        /// <param name="amount">Le montant à convertir</param>
        /// <returns>Le montant converti</returns>
        public Amount Convert(Amount amount)
        {
            if (amount.Currency == From)
                return new Amount(amount.Value * Rate.Value, To);

            if (amount.Currency == To)
                return new Amount(amount.Value * new Rate(1m / Rate.Value).Value, From);

            throw new ArgumentOutOfRangeException(nameof(amount), "Impossible de convertir le montant car il est dans une devise inconnue du taux de change");
        }
    }
}
