using System.Threading.Tasks;

namespace Singapor.ApplicationServices
{
	public interface IEmailSenderService
	{
		#region Public methods

		Task Send(string toEmailAddress, string emailSubject, string emailMessage);

		#endregion
	}
}