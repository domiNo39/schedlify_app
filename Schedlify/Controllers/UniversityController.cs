//COPYRIGHT NIGGERCODE
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
                { "s", namePart }
            };
            return await _apiClient.GetAsync<List<University>>("/universities", _userId, queryParams);
        }

        public async Task<University?> Add(string name)
        {
            var existingUniversities = await Search(name);

            if (existingUniversities != null && existingUniversities.Any())
            {
                return existingUniversities.First();
            }
            else
            {
                var newUniversityData = new
                {
                    Name = name
                };
                return await _apiClient.PostAsync<University>("/universities", _userId, newUniversityData);
            }
        }
    }
}