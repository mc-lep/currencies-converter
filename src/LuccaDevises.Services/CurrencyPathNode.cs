using LuccaDevises.Types;

namespace LuccaDevises.Services
{
    /// <summary>
    /// Noeud d'un chemin de devises
    /// </summary>
    internal class CurrencyPathNode
    {
        /// <summary>Un noeud vide</summary>
        public static readonly CurrencyPathNode Empty = new(Currency.Empty);

        /// <summary>
        /// Est-ce que le noeud est le noeud racine
        /// </summary>
        public bool IsRootNode { get; }

        /// <summary>
        /// Obtient la devise contenue dans le noeud
        /// </summary>
        public Currency Value { get; }

        /// <summary>
        /// Obtient le noeud précédent
        /// </summary>
        public CurrencyPathNode? Previous { get; set; }

        /// <summary>
        /// Est-ce que le noeud possède déjà un chemin ?
        /// </summary>
        public bool HasBestPath => IsRootNode || (Previous != null);

        /// <summary>
        /// Initialise un nouveau noeud de chemin de devise
        /// </summary>
        /// <param name="value">La devise que le noeud doit contenir</param>
        /// <param name="isRootNode">Est-ce que le noeud est un noeud racine ?</param>
        public CurrencyPathNode(Currency value, bool isRootNode = false)
        {
            Value = value;
            IsRootNode = isRootNode;
        }
    }
}
