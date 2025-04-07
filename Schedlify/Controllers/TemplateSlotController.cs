using Schedlify.Global;
using Schedlify.Models;
using Schedlify.Utils;

namespace Schedlify.Controllers
{
    public class TemplateSlotController
    {
        private readonly ApiClient _apiClient;

        public TemplateSlotController()
        {
            _apiClient = new ApiClient();
        }

        public TemplateSlotController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        private long GetCurrentUserId()
        {
            return UserSession.currentUser.Id;
        }

        public async Task<List<TemplateSlot>> GetByDepartmentId(long departmentId)
        {
            return await _apiClient.GetAsync<List<TemplateSlot>>($"/template-slots/by-department/{departmentId}", GetCurrentUserId());
        }

        public async Task AddTemplateSlots(long departmentId, List<Slot> slotList)
        {
            var templateSlotsData = new
            {
                DepartmentId = departmentId,
                Slots = slotList.OrderBy(s => s.startTime).Select((slot, index) => new
                {
                    StartTime = slot.startTime,
                    EndTime = slot.endTime,
                    Order = index
                }).ToList()
            };

            await _apiClient.PostAsync<object>("/template-slots/bulk", GetCurrentUserId(), templateSlotsData);
        }
    }
}