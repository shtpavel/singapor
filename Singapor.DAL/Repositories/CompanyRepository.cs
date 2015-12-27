using Singapor.Model.Entities;

namespace Singapor.DAL.Repositories
{
    public class CompanyRepository : BaseRepository<Company>
    {
        #region Constructors

        public CompanyRepository(IDataContext context) : base(context)
        {
        }

        #endregion
    }
}