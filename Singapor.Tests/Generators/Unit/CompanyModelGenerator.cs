﻿using Singapor.Helpers;
using Singapor.Services.Models;

namespace Singapor.Tests.Generators.Unit
{
	public class CompanyModelGenerator : IGenerator<CompanyModel>
	{
		#region Public methods

		public CompanyModel Get()
		{
			var model = new CompanyModel
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

		#endregion
	}
}