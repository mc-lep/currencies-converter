using LuccaDevises.Types;

namespace LuccaDevises.Services
{
    /// <summary>
    /// Chemin de parcours pour aller d'une devise à une autre
    /// </summary>
    internal class CurrencyPath
    {
        private readonly Dictionary<Currency, CurrencyPathNode> _dictionary;

        /// <summary>
        /// Constructeur
        /// </summary>
        public CurrencyPath()
        {
            _dictionary = new Dictionary<Currency, CurrencyPathNode>();
        }

        /// <summary>
        /// Obtient le noeud dans le chemin ou l'ajoute s'il n'existe pas encore
        /// </summary>
        /// <param name="currency">La devise cible du noeud</param>
        /// <returns>Le noeud trouvé ou nouvellement créé</returns>
        public CurrencyPathNode GetOrCreateNodeFor(Currency currency)
        {
            var node = GetNodeFor(currency);

            if (node != CurrencyPathNode.Empty)
            {
                return node;
            }

            var newNode = new CurrencyPathNode(currency);
            _dictionary.Add(currency, newNode);
            return newNode;
        }

        /// <summary>
        /// Crée le noeud racine du chemin
        /// </summary>
        /// <param name="currency">La devise cible du noeud</param>
        /// <returns>Le noeud créé</returns>
        public CurrencyPathNode CreateRootNodeFor(Currency currency)
        {
            var node = new CurrencyPathNode(currency, true);
            _dictionary.Add(currency, node);
            return node;
        }

        /// <summary>
        /// Obtient le noeud dans le chemin pour la devise demandée
        /// </summary>
        /// <param name="currency">La devise pour laquelle il faut obtenir le noeud</param>
        /// <returns>Le noeud trouvé ou bien <see cref="CurrencyPathNode.Empty"/> si le noeud n'a pas été trouvé</returns>
        public CurrencyPathNode GetNodeFor(Currency currency)
        {
            if (_dictionary.ContainsKey(currency))
            {
                return _dictionary[currency];
            }

            return CurrencyPathNode.Empty;
        }
    }
}
