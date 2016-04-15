using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Singapor.Resources
{
	public class CountriesProvider
	{
		#region Properties

		public IEnumerable<Country> Countries { get; private set; }

		#endregion

		#region Constructors

		public CountriesProvider()
		{
			var json = File.ReadAllText(AppResources.CulturesPath);
			Countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
		}

		#endregion
	}
}