using System;

namespace MassTransitSample
{
	public interface IEmployeeWentIn
	{
		DateTime Timestamp { get; }
		string EmployeeName { get; }
	}
}