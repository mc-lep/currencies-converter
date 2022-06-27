using LuccaDevises.Types;

namespace LuccaDevises.Services
{
    /// <summary>
    /// Graphe des taux de change
    /// </summary>
    internal class ExchangeRatesGraph
    {
        private readonly static ExchangeRate[] _emtpyEdges = Array.Empty<ExchangeRate>();

        private readonly Dictionary<Currency, List<ExchangeRate>> _edges;
        
        /// <summary>
        /// Construit un nouveau graphe de taux de change à partir de la liste des taux de changes
        /// </summary>
        /// <param name="exchangeRates">La liste des taux de change à utiliser pour construire le graphe</param>
        public ExchangeRatesGraph(IEnumerable<ExchangeRate> exchangeRates)
        {
            _edges = new Dictionary<Currency, List<ExchangeRate>>();
            
            ComputeExplicitEdges(exchangeRates);
            ComputeInvertedEdges(exchangeRates);
        }

        /// <summary>
        /// Alimente le graphe avec les taux de change dans le sens From -> To
        /// </summary>
        /// <param name="exchangeRates">La liste des taux de change à utiliser pour construire le graphe</param>
        private void ComputeExplicitEdges(IEnumerable<ExchangeRate> exchangeRates)
        {
            foreach (var exchangeRate in exchangeRates)
            {
                if (!_edges.ContainsKey(exchangeRate.From))
                {
                    _edges.Add(exchangeRate.From, new List<ExchangeRate>());
                }

                _edges[exchangeRate.From].Add(exchangeRate);
            }
        }

        /// <summary>
        /// Alimente le graphe avec les taux de change dans le sens To -> From
        /// </summary>
        /// <param name="exchangeRates">La liste des taux de change à utiliser pour construire le graphe</param>
        private void ComputeInvertedEdges(IEnumerable<ExchangeRate> exchangeRates)
        {
            foreach (var exchangeRate in exchangeRates)
            {
                if (!_edges.ContainsKey(exchangeRate.To))
                {
                    _edges.Add(exchangeRate.To, new List<ExchangeRate>());
                }

                _edges[exchangeRate.To].Add(exchangeRate);
            }
        }

        /// <summary>
        /// Obtient tous les taux de change pour une devise donnée
        /// </summary>
        /// <param name="currency">La devise pour laquelle il faut retrouver les taux de change</param>
        /// <returns>La liste des taux pour la devise demandée</returns>
        public IEnumerable<ExchangeRate> GetExchangeRatesFor(Currency currency)
        {
            if (_edges.TryGetValue(currency, out var edges))
            {
                return edges;
            }

            return _emtpyEdges;
        }
    }
}
