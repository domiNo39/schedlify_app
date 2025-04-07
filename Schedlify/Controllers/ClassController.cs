using Schedlify.Global;
using Schedlify.Models;

namespace Schedlify.Controllers
{
    public class ClassController
    {
        private readonly ApiClient _apiClient;
        private readonly long _userId;

        public ClassController()
        {
            _apiClient = new ApiClient();
            _userId = GetCurrentUserId();
        }
        public ClassController(ApiClient apiClient)
        {
            _apiClient = apiClient;
            _userId = GetCurrentUserId();
        }

        private long GetCurrentUserId()
        {
            return UserSession.currentUser.Id;
        }

        public async Task<List<Class>> GetByGroupId(long groupId)
        {
            return await _apiClient.GetAsync<List<Class>>($"/classes?groupId={groupId}", _userId);
        }

        public async Task<Class?> Add(long groupId, string name)
        {
            var newClassData = new
            {
                GroupId = groupId,
                Name = name
            };
            return await _apiClient.PostAsync<Class>("/classes", _userId, newClassData);
        }

        public async Task<Class?> Edit(long classId, string name)
        {
            var updatedClassData = new
            {
                Name = name
            };
            return await _apiClient.PostAsync<Class>($"/classes/{classId}", _userId, updatedClassData);
        }

        public async Task<bool> Delete(long classId)
        {
            try
            {
                await _apiClient.DeleteAsync<object>($"/classes/{classId}", _userId);
                return true;
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Error deleting class {classId}: Status Code {ex.StatusCode}, Message: {ex.Message}");
                return false;
            }
        }

        public async Task<Class> GetById(long classId)
        {
            return await _apiClient.GetAsync<Class>($"/classes/{classId}", _userId);
        }
    }
}