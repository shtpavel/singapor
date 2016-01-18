using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core.Lifetime;
using Microsoft.Owin.Security.OAuth;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Api.Auth
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IContainer _container;

        public SimpleAuthorizationServerProvider(IContainer container)
        {
            _container = container;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            
            var userService = _container.Resolve<IUserService>();
            var user = userService.Get(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));

            context.Validated(identity);
        }
    }
}
