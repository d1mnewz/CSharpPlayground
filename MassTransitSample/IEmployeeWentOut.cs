using System;

namespace MassTransitSample
{
	public interface IEmployeeWentOut
	{
		DateTime Timestamp { get; }
		string EmployeeName { get; }
	}
}