using Autofac;
using Singapor.ApplicationServices;

namespace Singapor.Infrastructure.DependencyInjection.Modules
{
	public class ApplicationServiceModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<EmailSenderService>().As<IEmailSenderService>();
		}
	}
}