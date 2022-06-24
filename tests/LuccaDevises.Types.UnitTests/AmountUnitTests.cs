namespace LuccaDevises.Types.UnitTests
{
    public class AmountUnitTests
    {
        [Fact]
        public void Value_ShouldBeSet_WithInitializeValue()
        {
            var instance = new Amount(1.234m);
            var result = instance.Value;

            Assert.Equal(1.234m, result);
        }
    }
}
