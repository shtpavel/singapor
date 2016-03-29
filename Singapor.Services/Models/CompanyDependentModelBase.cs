using Singapor.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singapor.Services.Models
{
	public class CompanyDependentModelBase : ModelBase
	{
		public Guid? CompanyId { get; set; }
	}
}
