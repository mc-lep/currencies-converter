namespace LuccaDevises.Types
{
    /// <summary>
    /// Une montant
    /// </summary>
    public readonly struct Amount
    {
        public decimal Value { get; }

        /// <summary>
        /// Initialize un montant
        /// </summary>
        /// <param name="value">Le valeur du montant</param>
        public Amount(decimal value)
        {
            Value = value;
        }
    }
}
