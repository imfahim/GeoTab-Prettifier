namespace Prettifier.Service;

public class Prettifier
{
	private readonly IEnumerable<IPrettificationStrategy> _strategies;

	public Prettifier(IEnumerable<IPrettificationStrategy> strategies)
	{
		_strategies = strategies;
	}

	public string Prettify(double number)
	{
		var strategy = _strategies.First(s => s.CanPrettify(number));
		return number < 0 ? "-" + strategy.Prettify(-number) : strategy.Prettify(number);
	}
}
