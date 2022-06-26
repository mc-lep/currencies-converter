using LuccaDevises.Types;

namespace LuccaDevises.UnitTests
{
    public class InputBuilderUnitTest
    {
        private const string ValidFirstLine = "EUR;550;JPY";
        private const string ValidSecondLine = "6";
        private const string ValidTextInput = ValidFirstLine + "\n" + ValidSecondLine;

        [Fact]
        public void Build_ShouldExtractInitialAmount_WhenFirstLineIsValid()
        {
            var input = ValidTextInput;
            using var stringReader = new StringReader(input);
            
            var result = InputBuilder.BuildFrom(stringReader);
            
            Assert.Equal(new Amount(550, "EUR"), result.InitialAmount);
        }

        [Fact]
        public void Build_ShouldExtractTargetCurrency_WhenFirstLineIsValid()
        {
            var input = ValidTextInput;
            using var stringReader = new StringReader(input);
            
            var result = InputBuilder.BuildFrom(stringReader);

            Assert.Equal(new Currency("JPY"), result.TargetCurrency);
        }

        [Fact]
        public void Build_ShouldSayIsNotValid_WhenFirstLineIsEmpty()
        {
            var input = string.Empty;
            using var stringReader = new StringReader(input);

            Assert.Throws<InvalidDataException>(() => InputBuilder.BuildFrom(stringReader));
        }

        [Fact]
        public void Build_ShouldSayIsNotValid_WhenFirstLineIsNotValid()
        {
            var input = "EUR;JPY";
            using var stringReader = new StringReader(input);

            Assert.Throws<InvalidDataException>(() => InputBuilder.BuildFrom(stringReader));
        }

        [Fact]
        public void Build_ShouldSayIsNotValid_WhenAmountIsNotNumeric()
        {
            var input = "EUR;A;JPY";
            using var stringReader = new StringReader(input);

            Assert.Throws<InvalidDataException>(() => InputBuilder.BuildFrom(stringReader));
        }

        [Fact]
        public void Build_ShouldExtractInitialExchangeRatesCount_WhenSecondLineIsValid()
        {
            var input = ValidTextInput;
            using var stringReader = new StringReader(input);

            var result = InputBuilder.BuildFrom(stringReader);

            Assert.Equal(6, result.DeclaredExchangeRatesCount);
        }

        [Fact]
        public void Build_ShouldSayIsNotValid_WhenSecondLineIsEmpty()
        {
            var input = ValidFirstLine;
            using var stringReader = new StringReader(input);

            Assert.Throws<InvalidDataException>(() => InputBuilder.BuildFrom(stringReader));
        }

        [Fact]
        public void Build_ShouldSayIsNotValid_WhenExchangesCountIsNotNumeric()
        {
            var input = ValidFirstLine + "\nAAA";
            using var stringReader = new StringReader(input);

            Assert.Throws<InvalidDataException>(() => InputBuilder.BuildFrom(stringReader));
        }
    }
}