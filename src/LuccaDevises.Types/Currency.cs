using System.Diagnostics.CodeAnalysis;

namespace LuccaDevises.Types
{
    /// <summary>
    /// Une devise
    /// </summary>
    public readonly struct Currency
    {
        public static readonly Currency Empty = new("   ");

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

        /// <summary>
        /// Retourne la représentation de la devisse sous forme de chaine de caractères 
        /// </summary>
        /// <returns>Une chaien de caractère représentant la devise</returns>
        public override string ToString()
        {
            return IsoCode;
        }

        /// <summary>
        /// Indique si l'objet passé en paramètre est égal à la devise
        /// </summary>
        /// <param name="obj">L'objet à comparer</param>
        /// <returns><Vrai si <paramref name="obj"/> est égal à la devise</returns>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return obj is Currency currency && Equals(currency);
        }

        /// <summary>
        /// Retourne le code de Hashage pour la devise
        /// </summary>
        /// <returns>Le code de hashage</returns>
        public override int GetHashCode()
        {
            return IsoCode.GetHashCode();
        }

        /// <summary>
        /// Indique si la devise passée en paramèter est égale à la devise
        /// </summary>
        /// <param name="currency">La devise à comparer</param>
        /// <returns>Vrai si <paramref name="currency"/> est égale à la devise</returns>
        public bool Equals(Currency currency)
        {
            return IsoCode == currency.IsoCode;
        }

        public static bool operator ==(Currency c1, Currency c2) => c1.Equals(c2);
        
        public static bool operator !=(Currency c1, Currency c2) => !c1.Equals(c2);
    }
}
