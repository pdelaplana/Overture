using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Overture.Core.Services;

namespace Overture.Infrastructure.Services.Auth0
{
	public class Auth0AuthenticationService : IAuthenticationService
	{
		private AuthenticationApiClient _client = null;
		private string _audience = null;
		private string _clientId = null;
		private string _clientSecret = null;
		private string _realm = "Username-Password-Authentication";

		public Auth0AuthenticationService(IOptions<Auth0Settings> options)
		{
			_client = new AuthenticationApiClient(options.Value.Domain);
			_audience = options.Value.Audience;
			_clientId = options.Value.ClientId;
			_clientSecret = options.Value.ClientSecret;
		}

		public async Task<AuthenticationResult> AuthenticateAsync(string userId, string password)
		{
			var result = await _client.GetTokenAsync(new ResourceOwnerTokenRequest {
				Audience = _audience,
				ClientId = _clientId,
				ClientSecret = _clientSecret,
				Realm = _realm,
				Username = userId,
				Password = password,
			});

			if (result != null && !string.IsNullOrEmpty(result.AccessToken))
			{
				return new AuthenticationResult
				{
					AccessToken = result.AccessToken,
					ExpiresIn = result.ExpiresIn,
					TokenType = result.TokenType
				};
			}

			return null;
		}

		public async Task<AuthenticationResult> AuthenticateByEmailAsync(string email, string password)
		{
			return await AuthenticateAsync(email, password);
		}

		
	}
}
