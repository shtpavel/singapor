using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Services.Events.Models;
using Singapor.Services.Abstract;

namespace Singapor.Infrastructure.Listeners
{
    public class CompanyCreatedListener : ListenerBase<CompanyCreated>
    {
        #region Fields

        private readonly IUserService _userService;

        #endregion

        #region Constructors

        public CompanyCreatedListener(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Public methods

        public override void Handle(CompanyCreated message)
        {
            _userService.CreateFromCompany(message.Data.Id.Value, message.Data.Email);
        }

        #endregion
    }
}
