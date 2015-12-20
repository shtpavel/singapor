using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Services.Models;
using Singapor.Tests.Generators.Helpers;

namespace Singapor.Tests.Generators
{
    public class CompanyModelGenerator : IGenerator<CompanyModel>
    {
        public CompanyModel Get()
        {
            var model = new CompanyModel()
            {
                Name = StringsGenerators.GenerateString(10),
                Address = StringsGenerators.GenerateString(100),
                Country = StringsGenerators.GenerateString(20),
                Description = StringsGenerators.GenerateString(199),
                Email = StringsGenerators.GenerateEmail(),
                Phone = StringsGenerators.GenerateString(9)
            };

            return model;
        }
    }
}
