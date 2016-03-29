using System.Collections.Generic;
using System.Linq;

namespace Singapor.Services.Responses
{
	public class ResponseBase
	{
		#region Properties

		public bool IsValid
		{
			get { return Errors == null || !Errors.Any(); }
		}

		public List<ErrorObject> Errors { get; private set; }

		#endregion

		#region Constructors

		protected ResponseBase(List<ErrorObject> errors)
		{
			Errors = errors;
		}

		#endregion
	}

	public class ErrorObject
	{
		#region Properties

		public IEnumerable<string> Fields { get; private set; }
		public ErrorType Type { get; private set; }
		public string Message { get; private set; }

		#endregion

		#region Constructors

		public ErrorObject(IEnumerable<string> fields, string message, ErrorType errorType)
		{
			Fields = fields;
			Message = message;
			Type = errorType;
		}

		#endregion
	}

	public enum ErrorType
	{
		NotFound,
		InternalError,
		Validation
	}
}