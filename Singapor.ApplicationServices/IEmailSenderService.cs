using System.Threading.Tasks;

namespace Singapor.ApplicationServices
{
    public interface IEmailSenderService
    {
        Task Send(string toEmailAddress, string emailSubject, string emailMessage);
    }
}