//COPYRIGHT NIGGERCODE
using Schedlify.Global;
using Schedlify.Models;

namespace Schedlify.Controllers
{
    public class GroupController
    {
        private readonly ApiClient _apiClient;

        public GroupController()
        {
            _apiClient = new ApiClient();
        }

        public GroupController(ApiClient apiClient)
        {
            _apiClient = apiClient;
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
                { "s", namePart }
            };
            return await _apiClient.GetAsync<List<Group>>("/groups", GetCurrentUserId(), queryParams);
        }

        public async Task<Group?> Add(long departmentId, long administratorId, string name)
        {
            var newGroupData = new
            {
                DepartmentId = departmentId,
                AdministratorId = administratorId,
                Name = name
            };

            return await _apiClient.PostAsync<Group>("/groups", GetCurrentUserId(), newGroupData);
        }

        public async Task<Group?> GetByAdministratorId(long administratorId)
        { 
            return (await _apiClient.GetAsync<List<Group>>($"/groups?administratorId={administratorId}", administratorId)).FirstOrDefault();
        }
    }
}