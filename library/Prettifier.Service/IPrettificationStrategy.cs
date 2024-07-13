namespace Prettifier.Service
{
	public interface IPrettificationStrategy
	{
		bool CanPrettify(double number);
		string Prettify(double number);
	}
}
