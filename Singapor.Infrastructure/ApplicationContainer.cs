using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Services;
using Unity;

namespace Singapor.Infrastructure
{
    public class ApplicationContainer
    {
        public IUnityContainer CreateContainer()
        {
            var container = new UnityContainer();
            RegisterDependencies(container);
            return container;
        }

        protected virtual void RegisterDependencies(IUnityContainer container)
        {
            //register context
            container.RegisterType<IDataContext, DataContext>(new PerThreadLifetimeManager());
            container.RegisterType<IUnitOfWork, DataContext>(new PerThreadLifetimeManager());

            //register repositories
            container.RegisterType<IRepository<Company>, CompanyRepository>();
            container.RegisterType<IRepository<Order>, OrderRepository>();
            container.RegisterType<IRepository<UnitSchedule>, ScheduleRepository>();
            container.RegisterType<IRepository<Unit>, UnitRepository>();
            container.RegisterType<IRepository<UnitType>, BaseRepository<UnitType>>();

            //register services
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<ICompanyService, CompanyService>();
            container.RegisterType<IUnitScheduleService, UnitScheduleService>();
            container.RegisterType<IUnitService, UnitService>();
            container.RegisterType<IUnitTypeService, UnitTypeService>();
        }
    }
}
