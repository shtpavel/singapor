using Autofac;
using Moq;
using Singapor.DAL;
using Singapor.Infrastructure;
using Singapor.Model.Entities;
using Singapor.Services.Models;
using Singapor.Tests.Generators;
using Singapor.Tests.Generators.Unit;
using Singapor.Tests.Infrastructure.Modules;

namespace Singapor.Tests
{
    internal class TestsContainer : ApplicationContainer
    {
        #region Private methods

        private IDataContext CreateDataContext()
        {
            var companyDbSet = new FakeDbSet<Company>();
            var orderDbSet = new FakeDbSet<Order>();
            var unitDbSet = new FakeDbSet<Unit>();
            var unitScheduleDbSet = new FakeDbSet<UnitSchedule>();
            var unitTypeDbSet = new FakeDbSet<UnitType>();
            var fieldDbSet = new FakeDbSet<Field>();

            var mockDataContext = new Mock<IDataContext>();
            mockDataContext.Setup(x => x.Set<Company>()).Returns(companyDbSet);
            mockDataContext.Setup(x => x.Set<Order>()).Returns(orderDbSet);
            mockDataContext.Setup(x => x.Set<Unit>()).Returns(unitDbSet);
            mockDataContext.Setup(x => x.Set<UnitSchedule>()).Returns(unitScheduleDbSet);
            mockDataContext.Setup(x => x.Set<UnitType>()).Returns(unitTypeDbSet);
            mockDataContext.Setup(x => x.Set<Field>()).Returns(fieldDbSet);

            return mockDataContext.Object;
        }

		#endregion

		protected override void RegisterModules(ContainerBuilder builder)
		{
            base.RegisterModules(builder);
			builder.RegisterModule<GeneratorsModule>();

            var context = CreateDataContext();
            builder.RegisterInstance(context).As<IDataContext>().SingleInstance();
            builder.RegisterInstance(context).As<IUnitOfWork>().SingleInstance();
            
        }
    }
}