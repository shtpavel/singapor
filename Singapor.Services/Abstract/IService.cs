using System;

namespace Singapor.Services.Abstract
{
    public interface IService<TModel> where TModel : class
    {
        Guid Create(TModel companyModel);
        void Delete(Guid id);
        Guid Update(TModel companyModel);
        TModel Get(Guid id);
    }
}