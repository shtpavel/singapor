using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Singapor.Helpers.Auth;
using Singapor.Model.Entities;
using Singapor.Texts;

namespace Singapor.DAL
{
	public class DatabaseInintializer : DropCreateDatabaseAlways<DataContext>
	{
		#region Private methods

		private static Company CreateCompany()
		{
			var defaultCompany = new Company()
			{
				Id = Guid.NewGuid(),
				Address = "5th Avenu, 12",
				Country = "USA",
				CreatedAt = DateTime.UtcNow,
				Description = "Default company",
				Email = "pavel.shtanko@gmail.com",
				Name = "DefaultCompany",
				Phone = "+380957552075",
				ZipCode = "49027"
			};
			return defaultCompany;
		}

		private void CreateRoles(DataContext context)
		{
			var list = new List<Role>();
			list.Add(new Role()
			{
				Id = RoleIds.SuperAdmin,
				Name = "SuperAdmin"
			});
			list.Add(new Role()
			{
				Id = RoleIds.CompanyAdmin,
				Name = "CompanyAdmin"
			});

			list.ForEach(x => context.Set<Role>().Add(x));
		}

		private void CreateUtilities(DataContext context, Company defaultCompany)
		{
			var list = new List<Utility>();
			list.Add(new Utility()
			{
				Id = Guid.NewGuid(),
				Name = "Haircut",
				Description = "",
				CompanyId = defaultCompany.Id,
				Company = defaultCompany
			});

			list.Add(new Utility()
			{
				Id = Guid.NewGuid(),
				Name = "Manicure",
				Description = "",
				CompanyId = defaultCompany.Id,
				Company = defaultCompany
			});
			list.ForEach(x => context.Set<Utility>().Add(x));
		}

		private static void CreateSuperUser(DataContext context, Company defaultCompany)
		{
			context.Set<Company>().Add(defaultCompany);

			var superAdmin = new User()
			{
				Id = Guid.NewGuid(),
				Company = defaultCompany,
				CompanyId = defaultCompany.Id,
				CreatedAt = DateTime.UtcNow,
				Email = "admin@admin.com",
				Password = PasswordHasher.Hash("admin"),
			};
			superAdmin.Roles.Add(context.Set<Role>().First(x => x.Id == RoleIds.SuperAdmin));

			context.Set<User>().Add(superAdmin);
		}

		private void CreateUnitTypes(DataContext context, Company defaultCompany)
		{
			var list = new List<UnitType>();
			list.Add(new UnitType
			{
				Id = Guid.NewGuid(),
				Name = "Department",
				Company = defaultCompany,
				CompanyId = defaultCompany.Id,
				IsContainer = true
			});

			list.Add(new UnitType
			{
				Id = Guid.NewGuid(),
				Name = "ServiceOffice",
				Company = defaultCompany,
				CompanyId = defaultCompany.Id,
				IsContainer = true,
				IsServiceable = true
			});

			list.Add(new UnitType
			{
				Id = Guid.NewGuid(),
				Name = "Room",
				Company = defaultCompany,
				CompanyId = defaultCompany.Id,
				IsContainer = true
			});

			list.Add(new UnitType
			{
				Id = Guid.NewGuid(),
				Name = "ServiceUnit",
				Company = defaultCompany,
				CompanyId = defaultCompany.Id,
				IsContainer = false,
				IsServiceable = true
			});

			list.ForEach(x => context.Set<UnitType>().Add(x));
		}

		#endregion

		protected override void Seed(DataContext context)
		{
			var defaultCompany = CreateCompany();

			context.Set<Company>().Add(defaultCompany);

			CreateRoles(context);
			CreateSuperUser(context, defaultCompany);
			CreateUnitTypes(context, defaultCompany);
			CreateServices(context, defaultCompany);

			base.Seed(context);
		}
	}
}