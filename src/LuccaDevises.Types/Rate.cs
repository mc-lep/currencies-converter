using System.Globalization;

namespace LuccaDevises.Types
{
    /// <summary>
    /// Taux
    /// </summary>
    public readonly struct Rate
    {
        /// <summary>Obtient la valeur du taux</summary>
        public decimal Value { get; }
        
        /// <summary>
        /// Initialise un nouveau taux avec la valeur passée en paramètre
        /// </summary>
        /// <param name="value">La valeur du taux</param>
        /// <exception cref="ArgumentOutOfRangeException">Exception levée lorsque <paramref name="value"/> n'est pas strictement positif</exception>
        public Rate(decimal value)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Le taux doit être strictement supérieur à zéro.");

            Value = Math.Round(value, 4);
        }

        /// <summary>
        /// Retourne la valeur du taux sous forme de chaine de caractères
        /// </summary>
        /// <returns>La valeur du taux sous forme de chaine de caractères</returns>
        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}