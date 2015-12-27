using Singapor.Model.Entities;

namespace Singapor.DAL.Repositories
{
    public class UnitRepository : BaseRepository<Unit>
    {
        #region Constructors

        public UnitRepository(IDataContext context)
            : base(context)
        {
        }

        #endregion
    }
}