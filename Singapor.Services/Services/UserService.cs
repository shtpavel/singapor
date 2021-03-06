﻿using System;
using System.Collections.Generic;
using System.Linq;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Helpers;
using Singapor.Helpers.Auth;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Events;
using Singapor.Services.Events.Models;
using Singapor.Services.Models;
using Singapor.Services.Responses;

namespace Singapor.Services.Services
{
	public class UserService : BaseService<UserModel, User>, IUserService
	{
		#region Fields

		private readonly IEventAggregatorProvider _eventAggregatorProvider;

		#endregion

		#region Constructors

		public UserService(
			IUnitOfWork unitOfWork,
            ITranslationsService translationsService,
			IRepository<User> repository,
			IEventAggregatorProvider eventAggregatorProvider) : base(unitOfWork, translationsService, repository)
		{
			_eventAggregatorProvider = eventAggregatorProvider;
		}

		#endregion

		#region Public methods

		public override SingleEntityResponse<UserModel> Create(UserModel model)
		{
			model.Password = PasswordHasher.Hash(model.Password);
			return base.Create(model);
		}

		public SingleEntityResponse<UserModel> CreateFromCompany(Guid companyId, string login)
		{
			var password = StringsGenerators.GenerateString(8);
			var model = new UserModel
			{
				Email = login,
				CompanyId = companyId,
				Password = PasswordHasher.Hash(password)
			};

			var response = base.Create(model);

			//TODO: this is dirty hack, need to unhash password form db
			model.Password = password;

			if (response.IsValid)
				_eventAggregatorProvider.GetEventAggregator().SendMessage(new UserCreated(model));

			return response;
		}

		public SingleEntityResponse<UserModel> Get(string email, string password)
		{
			var user =
				this._repository
					.GetAll()
					.SingleOrDefault(x => x.Email == email &&
					                      PasswordHasher.Verify(password, x.Password));

			if (user == null)
				return new SingleEntityResponse<UserModel>(null,
					new List<ErrorObject> {new ErrorObject(new[] {""}, "", ErrorType.NotFound)});

			return Get(user.Id);
		}

		#endregion
	}
}