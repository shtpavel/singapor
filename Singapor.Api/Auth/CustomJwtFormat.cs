﻿using System;
using System.IdentityModel.Tokens;
using System.Web.Configuration;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Thinktecture.IdentityModel.Tokens;

namespace Singapor.Api.Auth
{
	public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
	{
		#region Static fields and constants

		private const string AudiencePropertyKey = "audience";

		#endregion

		#region Fields

		private readonly string _issuer = string.Empty;

		#endregion

		#region Constructors

		public CustomJwtFormat(string issuer)
		{
			_issuer = issuer;
		}

		#endregion

		#region Public methods

		public string Protect(AuthenticationTicket data)
		{
			if (data == null)
				throw new ArgumentNullException("data");

			var audienceId = data.Properties.Dictionary.ContainsKey(AudiencePropertyKey)
				? data.Properties.Dictionary[AudiencePropertyKey]
				: null;
			if (string.IsNullOrWhiteSpace(audienceId))
				throw new InvalidOperationException("AuthenticationTicket.Properties does not include audience");
			var symmetricKeyAsBase64 = WebConfigurationManager.AppSettings["base64secret"];

			var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);
			var signingKey = new HmacSigningCredentials(keyByteArray);

			var issued = data.Properties.IssuedUtc;
			var expires = data.Properties.ExpiresUtc;

			var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime,
				expires.Value.UtcDateTime, signingKey);

			var handler = new JwtSecurityTokenHandler();

			var jwt = handler.WriteToken(token);

			return jwt;
		}

		public AuthenticationTicket Unprotect(string protectedText)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}