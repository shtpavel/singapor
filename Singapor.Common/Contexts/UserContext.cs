using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Singapor.Resources;

namespace Singapor.Common.Contexts
{
	public class UserContext : IUserContext
	{
		#region Properties

		public Guid? UserId
		{
			get
			{
				var identifier = ((ClaimsPrincipal) HttpContext.Current.User).FindFirst(ClaimTypes.NameIdentifier).Value;
				return string.IsNullOrEmpty(identifier) ? (Guid?) null : Guid.Parse(identifier);
			}
		}

		public Guid? UserCompanyId
		{
			get
			{
				var identifier = ((ClaimsPrincipal) HttpContext.Current.User).FindFirst(CustomClaims.CompanyId).Value;
				return string.IsNullOrEmpty(identifier) ? (Guid?) null : Guid.Parse(identifier);
			}
		}

		#endregion

		#region Public methods

		public bool IsInRole(Guid id)
		{
			var roles = ((ClaimsPrincipal) HttpContext.Current.User).FindAll(ClaimTypes.Role).Select(x => x.Value);
			return roles.Any(x => Guid.Parse(x) == id);
		}

		#endregion
	}
}