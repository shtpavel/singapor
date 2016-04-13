using System;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models
{
	public class UtilityModel : ModelBase
	{
		#region Properties

		public Guid? Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Guid? CompanyId { get; set; }

		#endregion
	}
}