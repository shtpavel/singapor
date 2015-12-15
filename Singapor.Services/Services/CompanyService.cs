using System;
using System.Collections.Generic;
using System.Linq;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Helpers;
using Singapor.Services.Models;
using Singapor.Services.Models.Validators.Company;
using Singapor.Services.Responses;

namespace Singapor.Services.Services
{
    public class CompanyService : BaseService<CompanyModel, Company>, ICompanyService
    { 
        #region Constructors

        public CompanyService(IUnitOfWork unitOfWork, IRepository<Company> repository) : base(unitOfWork,repository)
        {
        }

        public override SingleEntityResponse<CompanyModel> Create(CompanyModel model)
        {
            var newCopmanyValidator = new NewCompanyValidator();
            var validationResult = newCopmanyValidator.Validate(model);
            if (!validationResult.IsValid)
                return new SingleEntityResponse<CompanyModel>(model, validationResult.GetErrorsObjects().ToList());

            return base.Create(model);
        }

        #endregion
    }
}