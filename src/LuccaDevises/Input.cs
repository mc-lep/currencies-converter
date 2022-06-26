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
    }
}
