using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Services.Models
{
    public class RoleModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserModel> Users { get; set; }
    }
}
