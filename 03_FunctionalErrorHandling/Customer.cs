namespace _03_FunctionalErrorHandling
{
	public class Customer
	{
		public string Email { get; }

		public Customer()
		{
		}

		public bool CanBePromoted()
		{
			return true;
		}

		public void Promote()
		{
		}
	}
}