using System.Web;
using System.Web.Mvc;

namespace Singapor.Api.Company
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
