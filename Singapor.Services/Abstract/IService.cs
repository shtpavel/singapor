using System;
using Singapor.Services.Responses;

namespace Singapor.Services.Abstract
{
    public interface IService<TModel> where TModel : ModelBase
    {
        #region Public methods

        SingleEntityResponse<TModel> Create(TModel model);
        EmptyResponse Delete(Guid id);
        SingleEntityResponse<TModel> Get(Guid? id);
        ListEntityResponse<TModel> Get();
        SingleEntityResponse<TModel> Update(TModel model);

        #endregion
    }
}