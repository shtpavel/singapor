using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Configuration;
using Autofac;
using Autofac.Core.Lifetime;
using Microsoft.Owin.Security;
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

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var userService = _container.Resolve<IUserService>();
            var userResponse = userService.Get(context.UserName, context.Password);

            if (!userResponse.IsValid || userResponse.Data == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect");
                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity("JWT");
            identity.AddClaim(new Claim(ClaimTypes.Name, userResponse.Data.Email));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "superAdmin"));

            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                         "audience", WebConfigurationManager.AppSettings["audience"]
                    }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }
    }
}
