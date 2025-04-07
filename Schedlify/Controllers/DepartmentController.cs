using Schedlify.Global;
using Schedlify.Models;

namespace Schedlify.Controllers
{
    public class DepartmentController
    {
        private readonly ApiClient _apiClient;
        private readonly long _userId;

        public DepartmentController()
        {
            _apiClient = new ApiClient();
            _userId = GetCurrentUserId();
        }

        public DepartmentController(ApiClient apiClient)
        {
            _apiClient = apiClient;
            _userId = GetCurrentUserId();
        }

        private long GetCurrentUserId()
        {
            return UserSession.currentUser.Id;
        }

        public async Task<List<Department>> Search(long universityId, string namePart)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "universityId", universityId.ToString() },
                { "s", namePart }
            };
            return await _apiClient.GetAsync<List<Department>>("/departments", _userId, queryParams);
        }

        public async Task<Department?> Add(long universityId, string name)
        {
            var existingDepartments = await Search(universityId, name);

            if (existingDepartments != null && existingDepartments.Count > 0)
            {
                return existingDepartments[0];
            }
            else
            {
                var newDepartmentData = new
                {
                    UniversityId = universityId,
                    Name = name
                };
                return await _apiClient.PostAsync<Department>("/departments", _userId, newDepartmentData);
            }
        }

        public async Task<Department?> GetById(long id)
        {
            return await _apiClient.GetAsync<Department>($"/departments/{id}", _userId);
        }
    }
}