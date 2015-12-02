using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Singapor.Model.Entities;

namespace Singapor.DAL.Repositories
{
    public class CompanyRepository : BaseRepository<Company>
    {
        public CompanyRepository(IDataContext context) : base(context)
        {
            
        }
    }
}
