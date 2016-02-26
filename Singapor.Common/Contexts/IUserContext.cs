using System;

namespace Singapor.Common.Contexts
{
    public interface IUserContext
    {
        Guid? UserId { get; }
        Guid? UserCompanyId { get; }
        bool IsInRole(Guid id);
    }
}