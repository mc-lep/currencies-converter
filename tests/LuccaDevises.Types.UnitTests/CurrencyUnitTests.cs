namespace LuccaDevises.Types.UnitTests
{
    public class CurrencyUnitTests
    {
        [Fact]
        public void IsoCode_ShouldBeEqual_WhenValidInitialValue()
        {
            var instance = new Currency("EUR");
            var result = instance.IsoCode;

            Assert.Equal("EUR", result);
        }

        [Fact]
        public void IsoCode_ShouldConvertedToUpperCase_WhenLowerCaseInitialValue()
        {
            var instance = new Currency("eur");
            var result = instance.IsoCode;

            Assert.Equal("EUR", result);
        }

        [Fact]
        public void Initialize_ShouldSayEmptyValue_WhenInitialValueIsEmptyString()
        {
            Assert.Throws<ArgumentNullException>(() => new Currency(string.Empty));
        }

        [Fact]
        public void Initialize_ShouldSayInvalidValue_WhenInitialValueLengthIsNot3Characters()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Currency("AB"));
        }

        [Fact]
        public void Equals_ShouldBeFalse_WithNullValue()
        {
            var instance = new Currency("EUR");

            Assert.False(instance.Equals(null));
        }

        [Fact]
        public void Equals_ShouldBeTrue_WithSameValues()
        {
            var instance = new Currency("EUR");

            Assert.True(instance.Equals(new Currency("EUR")));
        }
    }
}
