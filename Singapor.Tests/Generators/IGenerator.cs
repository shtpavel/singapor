using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Tests.Generators
{
	public interface IGenerator<T> where T : ModelBase
	{
		#region Public methods

		T Get();

		#endregion
	}
}