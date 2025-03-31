
using Schedlify.Global;
using Schedlify.Models;

namespace Schedlify.Controllers
{
    public class UniversityController
    {
        private readonly ApiClient _apiClient;
        private readonly long _userId;

        public UniversityController()
        {
            _apiClient = new ApiClient();
            _userId = GetCurrentUserId();
        }

        public UniversityController(ApiClient apiClient)
        {
            _apiClient = apiClient;
            _userId = GetCurrentUserId();
        }

        private long GetCurrentUserId()
        {
            return UserSession.currentUser.Id;
        }

        public async Task<List<University>> Search(string namePart)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "namePart", namePart }
            };
            return await _apiClient.GetAsync<List<University>>("/universities/search", _userId, queryParams);
        }

        public async Task<University?> Add(string name)
        {
            var newUniversityData = new
            {
                Name = name
            };
            return await _apiClient.PostAsync<University>("/universities", _userId, newUniversityData);
        }
    }
}