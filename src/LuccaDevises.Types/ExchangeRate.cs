namespace LuccaDevises.Types
{
    /// <summary>
    /// Un taux de change
    /// </summary>
    public struct ExchangeRate
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
    }
}
