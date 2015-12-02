using System;
using Singapor.Services.Abstract;

namespace Singapor.Services.Models
{
    public class CompanyModel : ModelBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}