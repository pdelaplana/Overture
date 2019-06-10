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
using Overture.Core.Domain.ValueObjects;
using Overture.Core.Services;
using Microsoft.Extensions.Caching.Memory;

namespace Overture.Infrastructure.Services.Auth0
{
	public class UserMetadata
	{
		public AccountType AccountType { get; set; }
		public string DisplayName { get; set; }
		public StoredFile Picture { get; set; }
	}

	public class Auth0UserService : IUserService
	{
		private const string _usersKey = "usersKey";

		private ManagementApiClient _client = null;
		private IMemoryCache _memoryCache = null;

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
			UserMetadata userMetadata = JsonConvert.DeserializeObject<UserMetadata>(JsonConvert.SerializeObject(user.UserMetadata));
			return new OvertureUser
			{
				UserId = user.UserId,
				Email = user.Email,
				Name = userMetadata.DisplayName,
				Picture = userMetadata.Picture,
				AccountType = userMetadata.AccountType
			};
		}

		private async void RefreshCache()
		{
			var users = await _client.Users.GetAllAsync(new GetUsersRequest {});
			_memoryCache.Set(_usersKey, users.ToList());
		}

		private IEnumerable<User> UsersCache
		{
			get
			{
				IList<User> users = null;
				if (_memoryCache.TryGetValue<IList<User>>(_usersKey, out users))
				{
					return users;
				}
				else
				{
					return null;
				}
			}
		}
		public Auth0UserService(IOptions<Auth0ManagementSettings> options, IMemoryCache memoryCache)
		{
			var token = GetAccessToken(options);
			_client = new ManagementApiClient(token, options.Value.Domain);

			_memoryCache = memoryCache;
			RefreshCache();
		}

		public async Task<OvertureUser> CreateUserAsync(OvertureUser user, string password)
		{
			var auth0User = await _client.Users.CreateAsync(new UserCreateRequest {
				Connection = "Username-Password-Authentication",
				Email = user.Email,
				EmailVerified = true,
				Password = password,
				UserMetadata = new UserMetadata {
					DisplayName = user.Name,
					AccountType = user.AccountType,
					Picture = user.Picture
				},
			});
			return MapUser(auth0User);

		}

		public async Task<OvertureUser> GetUserByEmailAsync(string email)
		{
			IEnumerable<User> users = UsersCache;
			if (users != null)
			{
				users = users.Where(u => u.Email == email).ToList();
			}
			else
			{
				users = await _client.Users.GetUsersByEmailAsync(email);
			}
			return MapUser(users.FirstOrDefault());
		}

		public async Task<OvertureUser> GetUserAsync(string id)
		{
			IEnumerable<User> users = UsersCache;
			User user = null;
			if (users != null)
			{
				user = users.Where(u => u.UserId == id).FirstOrDefault();
			}
			else
			{
				user = await _client.Users.GetAsync(id);
			}
			return MapUser(user);
		}

		public async Task<OvertureUser> UpdateUserAsync(OvertureUser user)
		{
			var updated = await _client.Users.UpdateAsync(user.UserId, new UserUpdateRequest {

				UserMetadata = new UserMetadata
				{
					DisplayName = user.Name,
					AccountType = user.AccountType,
					Picture = user.Picture

				}
			});
			RefreshCache();
			return MapUser(updated);
		}

		public Task<bool> ResetPasswordAsync(string id)
		{
			throw new NotImplementedException();
		}
	}
}
