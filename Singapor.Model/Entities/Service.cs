using Singapor.Model.Entities.Abstract;

namespace Singapor.Model.Entities
{
	public class Service : CompanyDependentEntityBase
	{
		#region Properties

		public string Name { get; set; }
		public string Description { get; set; }

		#endregion
	}
}