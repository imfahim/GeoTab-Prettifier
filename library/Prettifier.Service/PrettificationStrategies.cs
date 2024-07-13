namespace Prettifier.Service
{
	public class MillionPrettificationStrategy : IPrettificationStrategy
	{
		public bool CanPrettify(double number) => Math.Abs(number) >= 1_000_000 && Math.Abs(number) < 900_000_000;

		public string Prettify(double number)
		{
			double prettifiedNumber = number / 1_000_000;
			return prettifiedNumber % 1 == 0 ? $"{(int)prettifiedNumber}M" : $"{Math.Round(prettifiedNumber, 1)}M";
		}
	}

	public class BillionPrettificationStrategy : IPrettificationStrategy
	{
		public bool CanPrettify(double number) => Math.Abs(number) >= 1_000_000_000 && Math.Abs(number) < 900_000_000_000;

		public string Prettify(double number)
		{
			double prettifiedNumber = number / 1_000_000_000;
			return prettifiedNumber % 1 == 0 ? $"{(int)prettifiedNumber}B" : $"{Math.Round(prettifiedNumber, 1)}B";
		}
	}

	public class TrillionPrettificationStrategy : IPrettificationStrategy
	{
		public bool CanPrettify(double number) => Math.Abs(number) >= 900_000_000_000;

		public string Prettify(double number)
		{
			double prettifiedNumber = number / 1_000_000_000_000;
			return prettifiedNumber % 1 == 0 ? $"{(int)prettifiedNumber}T" : $"{Math.Round(prettifiedNumber, 1)}T";
		}
	}

	public class DefaultPrettificationStrategy : IPrettificationStrategy
	{
		public bool CanPrettify(double number) => true;

		public string Prettify(double number) => number % 1 == 0 ? $"{(int)number}" : $"{number:F1}";
	}



}
