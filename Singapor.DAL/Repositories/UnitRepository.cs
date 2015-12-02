using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Model.Entities;

namespace Singapor.DAL.Repositories
{
    public class UnitRepository : BaseRepository<Unit>
    {
        public UnitRepository(IDataContext context)
            : base(context)
        {
        }
    }
}
