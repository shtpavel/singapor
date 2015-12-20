using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Singapor.DAL.Repositories;
using Singapor.Model;
using Singapor.Services.Abstract;
using Singapor.Texts;

namespace Singapor.Services.Models
{
    public class CommonValidator<T> : AbstractValidator<T> where T : ModelBase
    {
        public CommonValidator(IService<T> repository)
        {
            RuleFor(x => x.Id).NotNull().WithMessage(Validation.Required);
            RuleFor(x => x.Id).Must(x =>
            {
                if (x.HasValue)
                {
                    return repository.Get(x.Value).Data == null;
                }
                return true;
            }).WithMessage(Validation.UniqueId);
        }
    }
}
