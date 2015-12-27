using Singapor.Model.Entities;

namespace Singapor.DAL.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        #region Constructors

        public OrderRepository(IDataContext context)
            : base(context)
        {
        }

        #endregion
    }
}