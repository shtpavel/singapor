using Newtonsoft.Json;

namespace Singapor.Resources
{
	[JsonObject]
	public class Country
	{
		[JsonProperty]
		public string Name { get; set; }

		[JsonProperty]
		public string Code { get; set; }
	}
}