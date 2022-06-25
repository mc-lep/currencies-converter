using System.Diagnostics.CodeAnalysis;

namespace LuccaDevises.Types
{
    /// <summary>
    /// Une montant
    /// </summary>
    public readonly struct Amount
    {
        /// <summary>
        /// La valeur du montant
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// La devise dans laquelle le montant est exprimé
        /// </summary>
        public Currency Currency { get; }

        /// <summary>
        /// Initialize un montant
        /// </summary>
        /// <param name="value">Le valeur du montant</param>
        /// <param name="currencyIsCode">Le code iso de la devise dans laquelle le montant est exprimé</param>
        public Amount(decimal value, string currencyIsCode)
        {
            Value = Math.Round(value, 4);
            Currency = new Currency(currencyIsCode);
        }

        /// <summary>
        /// Initialize un montant
        /// </summary>
        /// <param name="value">Le valeur du montant</param>
        /// <param name="currency">La devise dans laquelle le montant est exprimé</param>
        public Amount(decimal value, Currency currency)
        {
            Value = Math.Round(value, 4);
            Currency = currency;
        }

        /// <summary>
        /// Retourne la représentation du montant sous forme de chaine de caractères
        /// </summary>
        /// <returns>Le montant sous forme de chaine de caractères</returns>
        public override string ToString()
        {
            return $"{Value:F4} {Currency.IsoCode}";
        }

        /// <summary>
        /// Indique si le montant passé en paramètre est égal au montant
        /// </summary>
        /// <param name="obj">Le montant à comparer</param>
        /// <returns>Vrai si <paramref name="obj"/> est égal au montant</returns>

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return obj is Amount amount && Equals(amount);
        }

        /// <summary>
        /// Indique si le montant passé en paramètre est égal au montant
        /// </summary>
        /// <param name="amount">Le montant à comparer</param>
        /// <returns>Vrai si <paramref name="amount"/> est égal au montant</returns>
        public bool Equals(Amount amount)
        {
            return Value == amount.Value && Currency == amount.Currency;
        }

        /// <summary>
        /// Retourne le code de hashage de la devise
        /// </summary>
        /// <returns>Le code de hashage</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode() ^ Currency.GetHashCode();
        }

        public static bool operator ==(Amount a1, Amount a2) => a1.Equals(a2);
        public static bool operator !=(Amount a1, Amount a2) => !a1.Equals(a2);
    }
}
