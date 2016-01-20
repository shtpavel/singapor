using Singapor.ApplicationServices;
using Singapor.Services.Events;
using Singapor.Services.Models;
using Singapor.Texts;

namespace Singapor.Infrastructure.EventAggregator.Listeners
{
    public class UserCreatedListener : ListenerBase<UserCreated>
    {
        private readonly IEmailSenderService _emailSenderService;

        public UserCreatedListener(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

        public override void Handle(UserCreated message)
        {
            var password = message.Data.Password;
            var login = message.Data.Email;

            var subject = EmailTexts.CompanyRegisteredSubject;
            var body = string.Format(EmailTexts.CompanyRegisteredBody, login, password);
            _emailSenderService.Send(login, subject, body);
        }
    }
}
