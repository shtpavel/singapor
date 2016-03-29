using System.Collections.Generic;
using Singapor.Services.Abstract;
using Singapor.Services.Responses;

namespace Singapor.Api.Classes
{
	public class Response<T> where T : ModelBase
	{
		#region Properties

		public T Data { get; private set; }
		public IEnumerable<ErrorObject> Errors { get; private set; }

		#endregion

		#region Constructors

		public Response(T data, IEnumerable<ErrorObject> errors)
		{
			Data = data;
			Errors = errors;
		}

		#endregion
	}
}