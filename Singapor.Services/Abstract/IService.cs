using System;
using System.Collections.Generic;
using Singapor.Services.Responses;

namespace Singapor.Services.Abstract
{
    public interface IService<TModel> where TModel : ModelBase
    {
        SingleEntityResponse<TModel> Create(TModel model);
        EmptyResponse Delete(Guid id);
        SingleEntityResponse<TModel> Update(TModel model);
        SingleEntityResponse<TModel> Get(Guid? id);
        ListResponse<TModel> Get();
    }
}