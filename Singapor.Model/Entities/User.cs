using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Singapor.Model.Entities.Abstract;

namespace Singapor.Model.Entities
{
    public class User : CompanyDependentEntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Role> Roles { get; set; } 
    }
}
