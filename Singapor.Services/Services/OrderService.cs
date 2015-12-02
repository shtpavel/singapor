using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Services.Services
{
    public class OrderService : BaseService<OrderModel, Order>, IOrderService
    {
        private readonly IRepository<UnitSchedule> _scheduleRepository;

        public OrderService(
            IRepository<Order> repository,
            IRepository<UnitSchedule> scheduleRepository) : base(repository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public override Guid Create(OrderModel model)
        {
            VerifyOrder(model);
            return base.Create(model);
        }

        private void VerifyOrder(OrderModel model)
        {
            //Todo: validate dates.
            //Todo: validate interceprion between other orders
            //Todo: marks with some tag like danger/ok/looksgood etc.
        }
    }
}
