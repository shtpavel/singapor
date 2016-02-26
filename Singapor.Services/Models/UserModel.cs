using System;
using System.Collections.Generic;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models
{
    public class UserModel : ModelBase
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public Guid? CompanyId { get; set; }
        public ICollection<RoleModel> Roles { get; set; } 
    }
}