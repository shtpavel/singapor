using System;

namespace Singapor.Common.Contexts
{
	public interface IUserContext
	{
		#region Properties

		Guid? UserId { get; }
		Guid? UserCompanyId { get; }

		#endregion

		#region Public methods

		bool IsInRole(Guid id);

		#endregion
	}
}