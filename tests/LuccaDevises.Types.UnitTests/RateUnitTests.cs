namespace LuccaDevises.Types.UnitTests
{
    public class RateUnitTests
    {
        [Fact]
        public void Value_ShouldBeEqualToInitialValue_WhenInitialValueHave4Decimals()
        {
            var instance = new Rate(1.1234m);
            var result = instance.Value;

            Assert.Equal(1.1234m, result);
        }

        [Fact]
        public void Value_ShouldBeEqualToInitialValue_WhenInitialValueHaveLessThan4Decimals()
        {
            var instance = new Rate(1.12m);
            var result = instance.Value;

            Assert.Equal(1.12m, result);
        }

        [Fact]
        public void Value_ShouldBeRoundedTo4Decimals_WhenInitialValueHaveMoreThan4Decimals()
        {
            var instance = new Rate(1.12341m);
            var result = instance.Value;

            Assert.Equal(1.1234m, result);
        }

        [Fact]
        public void Value_ShouldNotBeValid_WhenInitialValueIs0()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Rate(0m));
        }

        [Fact]
        public void Value_ShouldNotBeValid_WhenInitialValueIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Rate(-1m));
        }

        [Fact]
        public void ToString_ShouldReturnDotAsDecimalSeparator()
        {
            var instance = new Rate(1.1234m);
            var result = instance.ToString();

            Assert.Equal("1.1234", result);
        }
    }
}