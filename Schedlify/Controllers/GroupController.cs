using Schedlify.Global;
using Schedlify.Models;

namespace Schedlify.Controllers
{
    public class GroupController
    {
        private readonly ApiClient _apiClient;
        private readonly long _userId;

        public GroupController()
        {
            _apiClient = new ApiClient();
            _userId = GetCurrentUserId();
        }

        public GroupController(ApiClient apiClient)
        {
            _apiClient = apiClient;
            _userId = GetCurrentUserId();
        }

        private long GetCurrentUserId()
        {
            return UserSession.currentUser.Id;
        }

        public async Task<List<Group>> Search(long departmentId, string namePart)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "departmentId", departmentId.ToString() },
                { "namePart", namePart }
            };
            return await _apiClient.GetAsync<List<Group>>("/groups/search", _userId, queryParams);
        }

        public async Task<Group?> Add(long departmentId, long administratorId, string name)
        {
            var newGroupData = new
            {
                DepartmentId = departmentId,
                AdministratorId = administratorId,
                Name = name
            };
            return await _apiClient.PostAsync<Group>("/groups", _userId, newGroupData);
        }

        public async Task<Group?> GetByAdministratorId(long administratorId)
        {
            return await _apiClient.GetAsync<Group>($"/groups/by-administrator/{administratorId}", _userId);
        }
    }
}