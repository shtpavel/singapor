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

        private void VerifyOrder(OrderModel order)
        {
            //Maybe someone deside to make this date special
            var exactDateSchedule = _scheduleRepository
                .FilterBy(x => x.UnitId == order.UnitId && x.ExactDate == order.StartTime)
                .FirstOrDefault();
            var regularDaySchedule = _scheduleRepository
                .FilterBy(x => x.UnitId == order.UnitId && x.DayOfWeek == order.StartTime.DayOfWeek)
                .FirstOrDefault();
            var allOrders = _repository
                .FilterBy(x => x.UnitId == order.UnitId && x.StartTime.Date == order.StartTime.Date);

            var dateSchedule = exactDateSchedule ?? regularDaySchedule;
            var ordersStartHour = order.StartTime.Hour;

            if (dateSchedule == null)
            {
                throw new Exception("There is no schedule fot this day");
            }
            //Break if order is not in the day schedule bounds
            if (ordersStartHour < dateSchedule.OpenHour
                || ordersStartHour > dateSchedule.CloseHour)
            {
                throw new Exception("Out of day schedule bounds");
            }

            //Do not work in the break hours
            if (ordersStartHour == dateSchedule.BreakHour 
                || (ordersStartHour > dateSchedule.BreakHour && ordersStartHour < dateSchedule.BreakHour + dateSchedule.BreakDuration))
            {
                throw new Exception("Close in this hour");
            }

            //Time already booked
            if (allOrders.Any(x => x.StartTime == order.StartTime))
            {
                throw new Exception("We already have someone who booked this time");
            }


            //Todo: validate dates.
            //Todo: validate interceprion between other orders
            //Todo: marks with some tag like danger/ok/looksgood etc.
        }
    }
}
