using Singapor.Model.Entities;

namespace Singapor.DAL.Repositories
{
    public class ScheduleRepository : BaseRepository<UnitSchedule>
    {
        #region Constructors

        public ScheduleRepository(IDataContext context)
            : base(context)
        {
        }

        #endregion
    }
}