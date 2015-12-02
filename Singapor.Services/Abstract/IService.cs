using System;

namespace Singapor.Services.Abstract
{
    public interface IService<TModel> where TModel : ModelBase
    {
        Guid Create(TModel model);
        void Delete(Guid id);
        Guid Update(TModel model);
        TModel Get(Guid id);
    }
}