using System.Linq;
using System.Web.Security;
using Singapor.ApplicationServices;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Helpers;
using Singapor.Services.Models;
using Singapor.Services.Models.Validators.Company;
using Singapor.Services.Responses;
using Singapor.Texts;

namespace Singapor.Services.Services
{
    public class CompanyService : BaseService<CompanyModel, Company>, ICompanyService
    {
        private readonly IUserService _userService;

        #region Constructors

        public CompanyService(
            IUnitOfWork unitOfWork, 
            IRepository<Company> repository,
            IUserService userService) : base(unitOfWork, repository)
        {
            _userService = userService;
        }

        #endregion

        #region Public methods

        public override SingleEntityResponse<CompanyModel> Create(CompanyModel model)
        {
            var newCopmanyValidator = new NewCompanyValidator();
            var validationResult = newCopmanyValidator.Validate(model);
            if (!validationResult.IsValid)
                return new SingleEntityResponse<CompanyModel>(model, validationResult.GetErrorsObjects().ToList());

            var response = base.Create(model);

            if (response.IsValid)
            {
                var password = Membership.GeneratePassword(6, 0);
                var userCreationResponse = _userService.Create(new UserModel()
                {
                    Email = model.Email,
                    CompanyId = response.Data.Id,
                    Password = password
                });
            }

            return response;
        }

        #endregion
    }
}