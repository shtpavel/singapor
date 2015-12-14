using System;
using System.Collections.Generic;

namespace Singapor.Services.Abstract
{
    public interface IService<TModel> where TModel : ModelBase
    {
        Guid Create(TModel model);
        void Delete(Guid id);
        Guid Update(TModel model);
        TModel Get(Guid id);
        IEnumerable<TModel> Get();
    }
}