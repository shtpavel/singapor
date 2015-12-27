using System;
using System.Linq;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Services.Responses;

namespace Singapor.Services.Services
{
    public class OrderService : BaseService<OrderModel, Order>, IOrderService
    {
        #region Fields

        private readonly IRepository<UnitSchedule> _scheduleRepository;

        #endregion

        #region Constructors

        public OrderService(
            IUnitOfWork unitOfWork,
            IRepository<Order> repository,
            IRepository<UnitSchedule> scheduleRepository) : base(unitOfWork, repository)
        {
            _scheduleRepository = scheduleRepository;
        }

        #endregion

        #region Public methods

        public override SingleEntityResponse<OrderModel> Create(OrderModel model)
        {
            VerifyOrder(model);
            return base.Create(model);
        }

        #endregion

        #region Private methods

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
                ||
                (ordersStartHour > dateSchedule.BreakHour &&
                 ordersStartHour < dateSchedule.BreakHour + dateSchedule.BreakDuration))
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

        #endregion
    }
}