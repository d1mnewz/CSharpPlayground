using System;

namespace MassTransitSample
{
	public interface IEmployeeWentHome
	{
		DateTime Timestamp { get; }
		string EmployeeName { get; }
	}
}