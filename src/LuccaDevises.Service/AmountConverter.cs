using LuccaDevises.Types;

namespace LuccaDevises.Services
{
    /// <summary>
    /// Convertisseur de montant entre devises
    /// </summary>
    public class AmountConverter
    {
        private readonly List<ExchangeRate> _exchangeRates;
        private readonly ExchangeRatesGraph _currencyGraph;

        /// <summary>
        /// Initialise un nouveau convertisseur
        /// </summary>
        /// <param name="exchangeRates">La liste des taux de changes à utiliser pour la conversion</param>
        public AmountConverter(IEnumerable<ExchangeRate> exchangeRates)
        {
            _exchangeRates = new List<ExchangeRate>();

            if (exchangeRates != null)
            {
                _exchangeRates.AddRange(exchangeRates);
                _currencyGraph = new ExchangeRatesGraph(exchangeRates);
            }
            else
            {
                _currencyGraph = new ExchangeRatesGraph(new List<ExchangeRate>());
            }
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
            var path = GetShortestPath(initial.Currency, to);
            var exchanges = GetOrderedExchangesList(path, to);

            var amount = initial;
            foreach(var exchange in exchanges)
            {
                amount = exchange.Convert(amount);
            }
            return amount;
        }

        /// <summary>
        /// Calcule le chemin le plus court pour aller d'une devise de départ vers une devise d'arrivée
        /// </summary>
        /// <param name="from">La devise de départ</param>
        /// <param name="to">La devise d'arrivée</param>
        /// <returns>Le chemin à parcourir pour obtenir la devise d'arrivée depuis la devise de départ</returns>
        /// <exception cref="InvalidOperationException">Exception levée lorsque le chemin est impossible à calculer</exception>
        internal CurrencyPath GetShortestPath(Currency from, Currency to)
        {
            var currencyPath = new CurrencyPath();
            var currencyQueue = new Queue<CurrencyPathNode>();
            currencyQueue.Enqueue(currencyPath.CreateRootNodeFor(from));

            while (currencyQueue.Count > 0)
            {
                var currentNode = currencyQueue.Dequeue();
                foreach (var exchangeRate in _currencyGraph.GetExchangeRatesFor(currentNode.Value))
                {
                    var nextCurrency = exchangeRate.Other(currentNode.Value);
                    var nextNode = currencyPath.GetOrCreateNodeFor(nextCurrency);

                    if (nextNode.HasBestPath)
                        continue;
                    
                    nextNode.Previous = currentNode;

                    if (nextCurrency == to)
                    {
                        return currencyPath;
                    }
                    else
                    {
                        currencyQueue.Enqueue(nextNode);
                    }
                }
            }

            throw new InvalidOperationException($"Impossible de trouver un chemin depuis la devise {from} vers la devise {to}");
        }

        /// <summary>
        /// Obtient la liste des taux de change à utiliser pour suivre un chemin de devises
        /// </summary>
        /// <param name="path">Le chemin des devises</param>
        /// <param name="target">La devise cible qu'il faut atteindre</param>
        /// <returns>La liste ordonnées des taux de change à utiliser</returns>
        private List<ExchangeRate> GetOrderedExchangesList(CurrencyPath path, Currency target)
        {
            var list = new List<ExchangeRate>();
            var currentNode = path.GetNodeFor(target);

            while (currentNode != null)
            {
                if (currentNode.Previous == null)
                {
                    break;
                }

                var rates = _currencyGraph.GetExchangeRatesFor(currentNode.Value);
                var rate = rates.FirstOrDefault(r => r.CanConvert(currentNode.Value, currentNode.Previous.Value));
                list.Add(rate);

                currentNode = currentNode.Previous;
            }

            list.Reverse();
            return list;
        }
    }
}
