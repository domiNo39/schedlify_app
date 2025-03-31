//COPYRIGHT NIGGERCODE
using Schedlify.Models;

namespace Schedlify.Controllers
{
    public class UsersController
    {
        private readonly ApiClient _apiClient;
        private readonly long _userId = 0; //irrelevant?

        public UsersController()
        {
            _apiClient = new ApiClient();

        }

        public UsersController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<User?> Login(string login, string password)
        {
            var loginData = new
            {
                Login = login,
                Password = password
            };
            return await _apiClient.PostAsync<User>("/users/login", _userId, loginData);
        }

        public async Task<User?> Register(string login, string password)
        {
            var registerData = new
            {
                Login = login,
                Password = password
            };
            return await _apiClient.PostAsync<User>("/users/register", _userId, registerData);
        }
    }
}