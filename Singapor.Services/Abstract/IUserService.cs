﻿using System;
using Singapor.Services.Models;
using Singapor.Services.Responses;

namespace Singapor.Services.Abstract
{
	public interface IUserService : IService<UserModel>
	{
		#region Public methods

		SingleEntityResponse<UserModel> CreateFromCompany(Guid companyId, string login);
		SingleEntityResponse<UserModel> Get(string login, string password);

		#endregion
	}
}