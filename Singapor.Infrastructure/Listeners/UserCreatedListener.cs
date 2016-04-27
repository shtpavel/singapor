using Singapor.ApplicationServices;
using Singapor.Services.Events.Models;
using Singapor.Resources;
using Singapor.Services.Abstract;

namespace Singapor.Infrastructure.Listeners
{
	public class UserCreatedListener : ListenerBase<UserCreated>
	{
		#region Fields

		private readonly IEmailSenderService _emailSenderService;
	    private readonly ITranslationsService _translationsService;

	    #endregion

		#region Constructors

		public UserCreatedListener(IEmailSenderService emailSenderService, ITranslationsService translationsService)
		{
		    _emailSenderService = emailSenderService;
		    _translationsService = translationsService;
		}

	    #endregion

		#region Public methods

		public override void Handle(UserCreated message)
		{
			var password = message.Data.Password;
			var login = message.Data.Email;

			var subject = _translationsService.GetTranslationByKey("email.companyRegisteredSubject");
			var body = string.Format(_translationsService.GetTranslationByKey("email.companyRegisteredBody"), login, password);
			_emailSenderService.Send(login, subject, body);
		}

		#endregion
	}
}