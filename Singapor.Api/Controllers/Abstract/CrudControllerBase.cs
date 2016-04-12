using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Api.Controllers.Abstract
{
	public class CrudControllerBase<TService, TModel> : ControllerBase<TModel>
		where TService : IService<TModel>
		where TModel : ModelBase
	{
		#region Fields

		protected TService _service;

		#endregion

		#region Constructors

		protected CrudControllerBase(TService service)
		{
			_service = service;
		}

		#endregion

		#region Base CRUD operations

		[Authorize]
		public virtual HttpResponseMessage Get()
		{
			return GetResponse(_service.Get(), HttpStatusCode.OK);
		}

		[Authorize]
		public virtual HttpResponseMessage Get(Guid id)
		{
			return GetResponse(_service.Get(id), HttpStatusCode.Found);
		}

		[AllowAnonymous]
		public virtual HttpResponseMessage Post(TModel model)
		{
			return GetResponse(_service.Create(model), HttpStatusCode.Created);
		}

		#endregion
	}
}