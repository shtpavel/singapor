using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Singapor.DAL;
using Singapor.Infrastructure;
using Singapor.Model.Entities;
using Unity;

namespace Singapor.Tests
{
    public class TestsContainer : ApplicationContainer
    {
        protected override void RegisterDependencies(IUnityContainer container)
        {
            base.RegisterDependencies(container);
            var context = CreateDataContext();
            container.RegisterInstance(typeof (IDataContext), context, new PerThreadLifetimeManager());
            container.RegisterInstance(typeof(IUnitOfWork), context, new PerThreadLifetimeManager());
        }

        private IDataContext CreateDataContext()
        {
            var companyDbSet = new FakeDbSet<Company>();
            var orderDbSet = new FakeDbSet<Order>();
            var unitDbSet = new FakeDbSet<Unit>();
            var unitScheduleDbSet = new FakeDbSet<UnitSchedule>();
            var unitTypeDbSet = new FakeDbSet<UnitType>();

            var mockDataContext = new Mock<IDataContext>();
            mockDataContext.Setup(x => x.Set<Company>()).Returns(companyDbSet);
            mockDataContext.Setup(x => x.Set<Order>()).Returns(orderDbSet);
            mockDataContext.Setup(x => x.Set<Unit>()).Returns(unitDbSet);
            mockDataContext.Setup(x => x.Set<UnitSchedule>()).Returns(unitScheduleDbSet);
            mockDataContext.Setup(x => x.Set<UnitType>()).Returns(unitTypeDbSet);

            return mockDataContext.Object;
        }
    }
}
