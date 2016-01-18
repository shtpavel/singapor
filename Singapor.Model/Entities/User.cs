using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Model.Entities
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
