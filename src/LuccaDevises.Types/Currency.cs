namespace LuccaDevises.Types
{
    /// <summary>
    /// Une devise
    /// </summary>
    public readonly struct Currency
    {
        /// <summary>
        /// Obtient le code ISO de la devise
        /// </summary>
        public string IsoCode { get; }

        /// <summary>
        /// Initialise une nouvelle devise à partir de son code ISO
        /// </summary>
        /// <param name="isoCode">Le code ISO de la devise</param>
        /// <exception cref="ArgumentNullException"><paramref name="isoCode"/> est vide ou null</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="isoCode"/> ne fait pas 3 caractères</exception>
        public Currency(string isoCode)
        {
            if (string.IsNullOrEmpty(isoCode))
                throw new ArgumentNullException(nameof(isoCode), "La devise ne peut pas être vide.");

            if (isoCode.Length != 3)
                throw new ArgumentOutOfRangeException(nameof(isoCode), "La devise doit faire 3 caractères.");

            IsoCode = isoCode.ToUpperInvariant();
        }
    }
}
