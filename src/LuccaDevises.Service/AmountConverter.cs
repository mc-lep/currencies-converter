using LuccaDevises.Types;

namespace LuccaDevises.Services
{
    /// <summary>
    /// Convertisseur de montant entre devises
    /// </summary>
    public class AmountConverter
    {
        private readonly List<ExchangeRate> _exchangeRates;

        /// <summary>
        /// Initialise un nouveau convertisseur
        /// </summary>
        /// <param name="exchangeRates">La liste des taux de changes à utiliser pour la conversion</param>
        public AmountConverter(IEnumerable<ExchangeRate> exchangeRates)
        {
            _exchangeRates = new List<ExchangeRate>();
            
            if (exchangeRates != null)
                _exchangeRates.AddRange(exchangeRates);
        }

        /// <summary>
        /// Converti un montant depuis une devise vers la devise cible
        /// </summary>
        /// <param name="initial">Le montant initial</param>
        /// <param name="to">La devise cible</param>
        /// <returns>Le montant de la devise initiale converti vers la devise cible</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Amount Convert(Amount initial, Currency to)
        {
            foreach(var exchangeRate in _exchangeRates)
            {
                if (exchangeRate.CanConvert(initial.Currency, to))
                {
                    return exchangeRate.Convert(initial);
                }
            }

            throw new InvalidOperationException($"Impossible de convertir depuis la devise {initial.Currency} vers la devise {to}");
        }
    }
}
