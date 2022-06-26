using LuccaDevises.Types;

namespace LuccaDevises
{
    /// <summary>
    /// Données d'entrée pour le programme de conversion de devises
    /// </summary>
    public class Input
    {
        /// <summary>
        /// Le montant à convertir
        /// </summary>
        public Amount InitialAmount { get; set; }

        /// <summary>
        /// La devise vers laquelle il faut convertir le montant
        /// </summary>
        public Currency TargetCurrency { get; set; }

        /// <summary>
        /// Le nombre de ligne de taux de change déclaré dans les données d'entrée
        /// </summary>
        public int DeclaredExchangeRatesCount { get; set; }

        /// <summary>
        /// Les taux de changes à utiliser pour la conversion
        /// </summary>
        public List<ExchangeRate> ExchangeRates { get; set; }

        /// <summary>
        /// Initialise les données d'entrée
        /// </summary>
        public Input()
        {
            ExchangeRates = new List<ExchangeRate>();
        }
    }
}
