using LuccaDevises.Types;

namespace LuccaDevises.UnitTests
{
    public class InputBuilderUnitTest
    {
        [Fact]
        public void Build_ShouldExtractInitialAmount_WhenFirstLineIsValid()
        {
            var input = "EUR;550;JPY";
            using var stringReader = new StringReader(input);
            
            var result = InputBuilder.BuildFrom(stringReader);
            
            Assert.Equal(new Amount(550, "EUR"), result.InitialAmount);
        }

        [Fact]
        public void Build_ShouldExtractTargetCurrency_WhenFirstLineIsValid()
        {
            var input = "EUR;550;JPY";
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
    }
}