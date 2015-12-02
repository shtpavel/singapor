using System;

namespace Singapor.Common.Exceptions
{
	public class SingaporException : Exception
	{
		#region Constructors

		public SingaporException(string message) : base(message)
		{
		}

		#endregion
	}
}