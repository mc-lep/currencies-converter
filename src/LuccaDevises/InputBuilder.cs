using LuccaDevises.Types;
using System.Globalization;

namespace LuccaDevises
{
    /// <summary>
    /// Fabrique les données d'entrée depuis un flux texte
    /// </summary>
    public sealed class InputBuilder : IDisposable 
    {
        private readonly TextReader _inputStream;
        private readonly Input _input = new();
        
        /// <summary>
        /// Fabrique les données d'entrée depuis un flux texte
        /// </summary>
        /// <param name="inputStream">Le flux texte</param>
        /// <returns>Les données d'entrée</returns>
        /// <exception cref="ArgumentNullException">Exception levée lorsque le flux est null</exception>
        /// <exception cref="InvalidDataException">Le flux est mal formée</exception>
        public static Input BuildFrom(TextReader inputStream)
        {
            using var builder = new InputBuilder(inputStream);
            return builder.Build();
        }

        /// <summary>
        /// Intialise le builder pour la fabrication des données d'entrée
        /// </summary>
        /// <param name="inputStream">Le flux texte contenant les données d'entrées</param>
        /// <exception cref="ArgumentNullException">Exception levée lorsque le flux est null</exception>
        private InputBuilder(TextReader inputStream)
        {
            _inputStream = inputStream ?? throw new ArgumentNullException(nameof(inputStream), "Le flux ne peut pas être null");
        }

        /// <summary>
        /// Fabrique les données d'entrée
        /// </summary>
        /// <returns>Le données d'entrée pour le traitement de conversion</returns>
        private Input Build()
        {
            ReadNextLineAndExtractUserInput();
            ReadNextLineAndExtractExchangeRatesCount();

            for(var i = 0; i < _input.DeclaredExchangeRatesCount; i++)
            {
                ReadNextLineAndExtractExchangeRate();
            }

            return _input;
        }

        /// <summary>
        /// Lit la première ligne du flux et analyse les données
        /// </summary>
        /// <exception cref="InvalidDataException">La première ligne du flux est mal formée</exception>
        private void ReadNextLineAndExtractUserInput()
        {
            var line = _inputStream.ReadLine();
            if (line == null)
            {
                throw new InvalidDataException("La première ligne ne doit pas être vide");
            }

            var lineParts = line.Split(';');
            if (lineParts.Length != 3)
            {
                throw new InvalidDataException("La première ligne du fichier est mal formée, elle doit être de la forme CUR;AMT;CUR");
            }

            if (!int.TryParse(lineParts[1].Trim(), out var amount))
            {
                throw new InvalidDataException("La première ligne contient un montant mal formé, il doit être sous forme d'entier");
            }

            _input.InitialAmount = new Amount(amount, lineParts[0].Trim());
            _input.TargetCurrency = new Currency(lineParts[2].Trim());
        }

        /// <summary>
        /// Lit la seconde ligne du flux et analyse les données
        /// </summary>
        /// <exception cref="InvalidDataException">La seconde ligne du flux est mal formée</exception>
        private void ReadNextLineAndExtractExchangeRatesCount()
        {
            var line = _inputStream.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                return;
            }

            if (!int.TryParse(line.Trim(), out var count))
            {
                throw new InvalidDataException("La seconde ligne contient un nombre mal formé, il doit être sous forme d'entier");
            }

            _input.DeclaredExchangeRatesCount = count;
        }

        /// <summary>
        /// Lit la prochaineligne du flux et extrait un taux de change
        /// </summary>
        /// <exception cref="InvalidDataException"></exception>
        private void ReadNextLineAndExtractExchangeRate()
        {
            var line = _inputStream.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                return;
            }

            var lineParts = line.Split(';');
            if (lineParts.Length != 3)
            {
                throw new InvalidDataException("La ligne de taux de change est mal formée, elle doit être de la forme CUR;CUR;TAUX");
            }

            if (!decimal.TryParse(lineParts[2].Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out var rate))
            {
                throw new InvalidDataException("La ligne de taux de change contient un taux mal formé, il doit être sous forme de decimal");
            }

            _input.ExchangeRates.Add(new ExchangeRate(lineParts[0].Trim(), lineParts[1].Trim(), rate));
        }

        public void Dispose() => _inputStream.Dispose();
    }
}
