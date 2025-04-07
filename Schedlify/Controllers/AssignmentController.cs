using Schedlify.Models;
using Schedlify.Global;

namespace Schedlify.Controllers
{
    public class AssignmentController
    {
        private readonly ApiClient _apiClient;
        private readonly long _userId;

        public AssignmentController()
        {
            _apiClient = new ApiClient();
            _userId = GetCurrentUserId();
        }

        public AssignmentController(ApiClient apiClient)
        {
            _apiClient = apiClient;
            _userId = GetCurrentUserId();
        }

        private long GetCurrentUserId()
        {
            return UserSession.currentUser.Id;
        }

        public static bool IsEvenWeek(DateOnly date)
        {
            int weekOfYear = (date.DayOfYear - 1) / 7 + 1;
            return weekOfYear % 2 == 0;
        }

        public async Task<List<Assignment>> GetByGroupIdAndDate(long groupId, DateOnly date)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "groupId", groupId.ToString() },
                { "date", date.ToString("yyyy-MM-dd") }
            };
            return await _apiClient.GetAsync<List<Assignment>>("/assignments/by_group_id_and_date", _userId, queryParams);
        }

        public async Task<Assignment?> AddRegularAssignment(
            Weekday weekDay,
            int classNumber,
            long classId,
            string? lecturer = null,
            string? address = null,
            string? roomNumber = null,
            ClassType? classType = null,
            Mode? mode = null)
        {
            var newAssignmentData = new
            {
                GroupId = UserSession.currentGroup.Id,
                DepartmentId = UserSession.currentDepartment.Id,
                ClassId = classId,
                WeekDay = weekDay,
                ClassNumber = classNumber,
                AssignmentType = AssignmentType.Regular,
                Lecturer = lecturer,
                Address = address,
                RoomNumber = roomNumber,
                ClassType = classType,
                Mode = mode
            };

            return await _apiClient.PostAsync<Assignment>("/assignments/regular", _userId, newAssignmentData);
        }

        public async Task<Assignment?> AddIntervalAssignment(
            Weekday weekDay,
            int classNumber,
            long classId,
            AssignmentType assignmentType,
            string? lecturer = null,
            string? address = null,
            string? roomNumber = null,
            ClassType? classType = null,
            Mode? mode = null)
        {
            var newAssignmentData = new
            {
                GroupId = UserSession.currentGroup.Id,
                DepartmentId = UserSession.currentDepartment.Id,
                ClassId = classId,
                WeekDay = weekDay,
                ClassNumber = classNumber,
                Type = assignmentType,
                Lecturer = lecturer,
                Address = address,
                RoomNumber = roomNumber,
                ClassType = classType,
                Mode = mode
            };

            return await _apiClient.PostAsync<Assignment>("/assignments/interval", _userId, newAssignmentData);
        }

        public async Task<Assignment?> AddSpecialAssignment(
            DateOnly date,
            int classNumber,
            long classId,
            string? lecturer = null,
            string? address = null,
            string? roomNumber = null,
            ClassType? classType = null,
            Mode? mode = null)
        {
            var newAssignmentData = new
            {
                GroupId = UserSession.currentGroup.Id,
                DepartmentId = UserSession.currentDepartment.Id,
                ClassId = classId,
                Date = date,
                ClassNumber = classNumber,
                AssignmentType = AssignmentType.Special,
                Lecturer = lecturer,
                Address = address,
                RoomNumber = roomNumber,
                ClassType = classType,
                Mode = mode
            };

            return await _apiClient.PostAsync<Assignment>("/assignments/special", _userId, newAssignmentData);
        }

        public async Task Remove(long assignmentId)
        {
            await _apiClient.DeleteAsync<object>($"/assignments/{assignmentId}", _userId);
        }
    }
}