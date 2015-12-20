using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models
{
    public class UnitTypeModel : ModelBase
    {
        public UnitTypeModel()
        {
            Fields = new List<FieldModel>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? CompanyId { get; set; }

        public ICollection<FieldModel> Fields { get; set; }
    }
}
