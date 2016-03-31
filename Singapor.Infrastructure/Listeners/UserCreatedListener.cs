using Singapor.ApplicationServices;
using Singapor.Services.Events.Models;
using Singapor.Texts;

namespace Singapor.Infrastructure.Listeners
{
	public class UserCreatedListener : ListenerBase<UserCreated>
	{
		#region Fields

		private readonly IEmailSenderService _emailSenderService;

		#endregion

		#region Constructors

		public UserCreatedListener(IEmailSenderService emailSenderService)
		{
			_emailSenderService = emailSenderService;
		}

		#endregion

		#region Public methods

		public override void Handle(UserCreated message)
		{
			var password = message.Data.Password;
			var login = message.Data.Email;

			var subject = EmailTexts.CompanyRegisteredSubject;
			var body = string.Format(EmailTexts.CompanyRegisteredBody, login, password);
			_emailSenderService.Send(login, subject, body);
		}

		#endregion
	}
}