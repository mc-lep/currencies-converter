using LuccaDevises.Types;

namespace LuccaDevises.Services.UnitTests
{
    internal static class CurrencyPathNodeExtensions
    {
        /// <summary>
        /// Retourne le code iso de la devise contenu dans le noeud en remontant <paramref name="parentsCount"/> parents
        /// </summary>
        /// <param name="node">Le noeud pour lequel il faut récuperer la valeur</param>
        /// <param name="parentsCount">Le nombre de parent à remonter pour renvoyer la devise demandée</param>
        /// <returns>Le code iso d'une devise</returns>
        public static string GetIsoCode(this CurrencyPathNode node, int parentsCount)
        {
            var step = 0;
            var currentNode = node;
            var result = string.Empty;

            while (step < parentsCount && currentNode != null)
            {
                result = currentNode.Value.IsoCode;
                currentNode = currentNode.Previous;
                step++;
            }

            return result;
        }
    }

    public class AmountConverterUnitTests
    {
        [Fact]
        public void Convert_ShouldConvertToTargetCurreny_WhenExchangeRateExplicitlyExists()
        {
            var exchangeRates = new ExchangeRate[]
            {
                new ExchangeRate("EUR", "CHF", 1.2053m)
            };

            var instance = new AmountConverter(exchangeRates);
            var result = instance.Convert(new Amount(550, "EUR"), new Currency("CHF"));

            Assert.Equal(new Amount(662.9150m, "CHF"), result);
        }

        [Fact]
        public void Convert_ShouldConvertToTargetCurreny_WhenInvertExchangeRateExplicitlyExists()
        {
            var exchangeRates = new ExchangeRate[]
            {
                new ExchangeRate("AUD", "CHF", 0.9661m)
            };

            var instance = new AmountConverter(exchangeRates);
            var result = instance.Convert(new Amount(662.9150m, "CHF"), new Currency("AUD"));

            Assert.Equal(new Amount(686.1833m, "AUD"), result);
        }

        [Fact]
        public void Convert_ShouldConvertToTargetCurreny_WhenConversionHas2Steps()
        {
            var exchangeRates = new ExchangeRate[]
            {
                new ExchangeRate("EUR", "CHF", 1.2053m),
                new ExchangeRate("AUD", "CHF", 0.9661m),
                new ExchangeRate("AUD", "JPY", 86.0305m)
            };

            var instance = new AmountConverter(exchangeRates);
            var result = instance.Convert(new Amount(550m, "EUR"), new Currency("JPY"));

            Assert.Equal(new Amount(59032.6924m, "JPY"), result);
        }

        [Fact]
        public void GetShortestPath_ShouldGetCorrectPath_WhenConversionHas2Steps()
        {
            var exchangeRates = new ExchangeRate[]
            {
                new ExchangeRate("EUR", "CHF", 1.2053m),
                new ExchangeRate("AUD", "CHF", 0.9661m),
                new ExchangeRate("AUD", "JPY", 86.0305m)
            };

            var instance = new AmountConverter(exchangeRates);
            var result = instance.GetShortestPath(new Currency("EUR"), new Currency("JPY")).GetNodeFor(new Currency("JPY"));

            Assert.Equal("EUR", result.GetIsoCode(4));
            Assert.Equal("CHF", result.GetIsoCode(3));
            Assert.Equal("AUD", result.GetIsoCode(2));
            Assert.Equal("JPY", result.GetIsoCode(1));
        }

        [Fact]
        public void GetShortestPath_ShouldGetShortestPath_When2PathesExists()
        {
            var exchangeRates = new ExchangeRate[]
            {
                new ExchangeRate("EUR", "USD", 1.0003m), // Long Path
                new ExchangeRate("USD", "XAU", 0.0008m), // Long Path
                new ExchangeRate("XAU", "BOB", 1.0008m), // Long Path
                new ExchangeRate("BOB", "JPY", 0.0058m), // Long Path
                new ExchangeRate("EUR", "CHF", 1.2053m), // Short Path
                new ExchangeRate("AUD", "CHF", 0.9661m), // Short Path
                new ExchangeRate("AUD", "JPY", 86.0305m) // Short Path
            };

            var instance = new AmountConverter(exchangeRates);
            var result = instance.GetShortestPath(new Currency("EUR"), new Currency("JPY")).GetNodeFor(new Currency("JPY"));

            Assert.Equal("EUR", result.GetIsoCode(4));
            Assert.Equal("CHF", result.GetIsoCode(3));
            Assert.Equal("AUD", result.GetIsoCode(2));
            Assert.Equal("JPY", result.GetIsoCode(1));
        }

        [Fact]
        public void GetShortestPath_ShouldGetShortestPath_When2MixedPathesExists()
        {
            var exchangeRates = new ExchangeRate[]
            {
                new ExchangeRate("EUR", "USD", 1.0003m), // Path 1
                new ExchangeRate("USD", "XAU", 0.0008m), // Path 1
                new ExchangeRate("XAU", "AUD", 1.0008m), // Path 1 
                new ExchangeRate("AUD", "BOB", 0.0058m), // Path 1 + Path 2
                new ExchangeRate("EUR", "CHF", 1.2053m), // PAth 2
                new ExchangeRate("AUD", "CHF", 0.9661m), // Path 1 + Path 2
                new ExchangeRate("AUD", "JPY", 86.0305m) // Path 2
            };

            var instance = new AmountConverter(exchangeRates);
            var result = instance.GetShortestPath(new Currency("EUR"), new Currency("JPY")).GetNodeFor(new Currency("JPY"));

            Assert.Equal("EUR", result.GetIsoCode(4));
            Assert.Equal("CHF", result.GetIsoCode(3));
            Assert.Equal("AUD", result.GetIsoCode(2));
            Assert.Equal("JPY", result.GetIsoCode(1));
        }
    }
}
