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
    public class CommonValidator<T> : AbstractValidator<T> where T : BaseEntity
    {
        public CommonValidator(IRepository<T> repository)
        {
            RuleFor(x => x.Id).Must(x => repository.GetById(x) == null).WithMessage(Validation.UniqueId);
        }
    }
}
