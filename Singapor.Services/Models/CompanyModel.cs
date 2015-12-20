using System;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models
{
    public class CompanyModel : ModelBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
    }
}