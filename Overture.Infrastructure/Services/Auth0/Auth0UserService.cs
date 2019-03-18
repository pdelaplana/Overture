using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using RestSharp;
using Newtonsoft.Json;
using Overture.Core.Services;

namespace Overture.Infrastructure.Services.Auth0
{
	public class Auth0UserService : IUserService
	{
		private ManagementApiClient _client = null;

		private string GetAccessToken(IOptions<Auth0ManagementSettings> options)
		{
			var restClient = new RestClient($"https://{options.Value.Domain}/oauth/token");
			var request = new RestRequest(Method.POST);
			request.AddHeader("content-type", "application/json");
			request.AddParameter("application/json", JsonConvert.SerializeObject(new
			{
				grant_type = "client_credentials",
				client_id = options.Value.ClientId,
				client_secret = options.Value.ClientSecret,
				audience = options.Value.Audience,
			}), ParameterType.RequestBody);
			IRestResponse<Auth0AccessToken> response = restClient.Execute<Auth0AccessToken>(request);
			return response.Data.AccessToken;
		}

		private OvertureUser MapUser(User user)
		{
			if (user == null) return null;
			return new OvertureUser
			{
				UserId = user.UserId,
				Email = user.Email,
				Name = user.UserName,
				DisplayName = user.FullName
			};
		}

		public Auth0UserService(IOptions<Auth0ManagementSettings> options)
		{
			var token = GetAccessToken(options);
			_client = new ManagementApiClient(token, options.Value.Domain);
		}

		public async Task<OvertureUser> CreateUserAsync(OvertureUser user, string password)
		{
			var auth0User = await _client.Users.CreateAsync(new UserCreateRequest {
				Connection = "Username-Password-Authentication",
				Email = user.Email,
				EmailVerified = true,
				Password = password,
				UserMetadata = new { registeredAsBusiness = user.RegisteredAsBusiness }, 
			});
			return MapUser(auth0User);
			
		}

		public async Task<OvertureUser> GetUserByEmailAsync(string email)
		{
			var users = await _client.Users.GetUsersByEmailAsync(email);
			return MapUser(users.FirstOrDefault());
		}

		
	}
}
