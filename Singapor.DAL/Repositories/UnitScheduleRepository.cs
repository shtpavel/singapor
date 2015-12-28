using Singapor.Model.Entities;

namespace Singapor.DAL.Repositories
{
    public class UnitScheduleRepository : BaseRepository<UnitSchedule>
    {
        #region Constructors

        public UnitScheduleRepository(IDataContext context)
            : base(context)
        {
        }

        #endregion
    }
}