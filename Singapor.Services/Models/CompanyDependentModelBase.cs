using System;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models
{
	public class CompanyDependentModelBase : ModelBase
	{
		#region Properties

		public Guid? CompanyId { get; set; }

		#endregion
	}
}