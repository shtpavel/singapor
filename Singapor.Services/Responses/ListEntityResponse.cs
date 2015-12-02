using System.Collections.Generic;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Services.Responses
{
	public class ListEntityResponse<T> : ResponseBase where T : ModelBase
	{
		#region Properties

		public IEnumerable<SingleEntityResponse<T>> Data { get; private set; }

		#endregion

		#region Constructors

		public ListEntityResponse(IEnumerable<SingleEntityResponse<T>> data, List<ErrorObject> errors = null) : base(errors)
		{
			Data = data;
		}

		#endregion
	}
}