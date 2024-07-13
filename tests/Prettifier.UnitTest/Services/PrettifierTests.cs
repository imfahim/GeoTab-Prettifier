namespace Prettifier.Services;

public class PrettifierTests
{
    private readonly Service.Prettifier _prettifier;

    public PrettifierTests()
    {
        var strategies = new List<IPrettificationStrategy>
        {
            new TrillionPrettificationStrategy(),
            new BillionPrettificationStrategy(),
            new MillionPrettificationStrategy(),
            new DefaultPrettificationStrategy()
        };
        _prettifier = new Service.Prettifier(strategies);
    }

    [Theory]
    [InlineData(1000000, "1M")]
    [InlineData(2500000.34, "2.5M")]
    [InlineData(532, "532")]
    [InlineData(1123456789, "1.1B")]
    [InlineData(999999999999, "1T")]
    [InlineData(1234567, "1.2M")]
    [InlineData(-1234567, "-1.2M")]
    [InlineData(1234567890123, "1.2T")]
    [InlineData(1234567890.123, "1.2B")]
    public void Prettify_ReturnsExpectedResults(double input, string expected)
    {
        var result = _prettifier.Prettify(input);
        Assert.Equal(expected, result);
    }
}
