using Autofac;
using Moq;
using Singapor.ApplicationServices;
using Singapor.Common.Contexts;
using Singapor.DAL;
using Singapor.Infrastructure;
using Singapor.Model.Entities;
using Singapor.Tests.Infrastructure.Modules;

namespace Singapor.Tests.Infrastructure
{
	internal class TestsContainer : ApplicationContainer
	{
        #region Fields

        private Mock<IEmailSenderService> _emailMoq;

        #endregion

        #region Prop

        public Mock<IEmailSenderService> EmailSenderMoq
        {
            get { return _emailMoq; }
        }

        #endregion

        #region Private methods

        private IDataContext CreateDataContext()
		{
			var companyDbSet = new FakeDbSet<Company>();
			var unitDbSet = new FakeDbSet<Unit>();
			var unitTypeDbSet = new FakeDbSet<UnitType>();
			var userDbSet = new FakeDbSet<User>();
            var utilityDbSet = new FakeDbSet<Utility>();

			var mockDataContext = new Mock<IDataContext>();
			mockDataContext.Setup(x => x.Set<Company>()).Returns(companyDbSet);
			mockDataContext.Setup(x => x.Set<Unit>()).Returns(unitDbSet);
			mockDataContext.Setup(x => x.Set<UnitType>()).Returns(unitTypeDbSet);
			mockDataContext.Setup(x => x.Set<User>()).Returns(userDbSet);
            mockDataContext.Setup(x => x.Set<Utility>()).Returns(utilityDbSet);

            return mockDataContext.Object;
		}

		#endregion

		protected override void RegisterModules(ContainerBuilder builder)
		{
			base.RegisterModules(builder);
			builder.RegisterModule<GeneratorsModule>();

            _emailMoq = new Mock<IEmailSenderService>();        
            builder.RegisterInstance(_emailMoq.Object).As<IEmailSenderService>();

            var context = CreateDataContext();
            builder.RegisterInstance(context).As<IDataContext>().As<IUnitOfWork>().SingleInstance();
			builder.RegisterType<UserContext>().As<IUserContext>();
        }
	}
}