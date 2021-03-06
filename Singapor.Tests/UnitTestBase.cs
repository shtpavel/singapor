﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Services.Models.Maps;
using Singapor.Services.Responses;
using Singapor.Tests.Generators;
using Singapor.Tests.Infrastructure;
using Singapor.Resources;
using Singapor.Services.Events;
using Singapor.ApplicationServices;

namespace Singapor.Tests
{
	public class UnitTestBase
	{
        #region Fields

        protected IContainer _container;

        protected IGenerator<CompanyModel> _companyGenerator;
		protected ICompanyService _companyService;

		protected IUnitModelGenerator _unitModelGenerator;
		protected IUnitService _unitService;

		protected IUnitTypeModelGenerator _unitTypeModelGenerator;
		protected IUnitTypeService _unitTypeService;

        protected IUserService _userService;

        protected IUtilityModelGenerator _utilityModelGenerator;
        protected IUtilityService _utilitySerivce;
	    protected ITranslationsService _translationsService;

        protected Moq.Mock<IEmailSenderService> _emailSenderMock;

        #endregion

        #region Constructors

        public UnitTestBase()
		{
            var testContainer = new TestsContainer();
            _container = testContainer.GetContainerBuilder();
            _container.Resolve<IEnumerable<IMapConfiguration>>().ToList().ForEach(x => x.Map());
            _container.Resolve<IEventRegisterListeners>().RegisterListeners();
            _translationsService = _container.Resolve<ITranslationsService>();

            _emailSenderMock = testContainer.EmailSenderMoq;

            HttpContext.Current = HttpContext.Current = new HttpContext(
				new HttpRequest("", "http://tempuri.org", ""),
				new HttpResponse(new StringWriter())
				);

			HttpContext.Current.User = new GenericPrincipal(
				new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Role, RoleIds.SuperAdmin.ToString()),
					new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
				}),
				new string[0]
				);
		}

		#endregion

		#region Public methods

		#region AssertionHelpers

		public void AssertValidationErrorIsInList(string errorMessage, ResponseBase response, string property = null)
		{
			Assert.IsFalse(response.IsValid);
			if (property != null)
				Assert.IsTrue(response.Errors.Any(x => x.Message.Equals(errorMessage) && x.Fields.Contains(property)));
			else
				Assert.IsTrue(response.Errors.Any(x => x.Message.Equals(errorMessage)));
			Assert.AreEqual(
				response.Errors.First(x => x.Message.Equals(errorMessage)).Type,
				ErrorType.Validation);
		}

		#endregion

		public virtual void Setup()
		{
			_companyGenerator = _container.Resolve<IGenerator<CompanyModel>>();
			_companyService = _container.Resolve<ICompanyService>();

            _unitModelGenerator = _container.Resolve<IUnitModelGenerator>();
            _unitService = _container.Resolve<IUnitService>();
			
			_unitTypeModelGenerator = _container.Resolve<IUnitTypeModelGenerator>();
			_unitTypeService = _container.Resolve<IUnitTypeService>();

            _userService = _container.Resolve<IUserService>();

            _utilityModelGenerator = _container.Resolve<IUtilityModelGenerator>();
            _utilitySerivce = _container.Resolve<IUtilityService>();
        }

		#endregion

		protected CompanyModel CreateCompany()
		{
            return _companyService.Create(_container.Resolve<IGenerator<CompanyModel>>().Get()).Data;
		}

		protected UnitTypeModel CreateUnitType(CompanyModel companyModel)
		{
			return
				_container.Resolve<IUnitTypeService>()
					.Create(_container.Resolve<IUnitTypeModelGenerator>().Get(companyModel))
					.Data;
		}

		protected UnitModel CreateUnit(CompanyModel companyModel, UnitTypeModel unitTypeModel)
		{
			return _container.Resolve<IUnitService>()
				.Create(_container.Resolve<IUnitModelGenerator>().Get(companyModel, unitTypeModel))
				.Data;
		}
	}
}