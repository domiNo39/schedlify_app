using NLog; // Import NLog
using Schedlify.Data;
using Schedlify.Models;
using Schedlify.Repositories;
using Schedlify.Global;


namespace Schedlify.Controllers
{
    public class AssignmentController
    {
        private readonly AssignmentsRepository assigmentRepository;
        private readonly TemplateSlotRepository templateSlotRepository;
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger(); // Initialize NLog logger

        public AssignmentController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            this.assigmentRepository = new AssignmentsRepository(_context);
            this.templateSlotRepository = new TemplateSlotRepository(_context);
            logger.Info("AssignmentController initialized with default DbContext.");
        }

        public AssignmentController(ApplicationDbContext context)
        {
            ApplicationDbContext _context = context;
            this.assigmentRepository = new AssignmentsRepository(_context);
            this.templateSlotRepository = new TemplateSlotRepository(_context);
            logger.Info("AssignmentController initialized with provided DbContext.");
        }

        public static bool IsEvenWeek(DateOnly date)
        {
            int weekOfYear = (date.DayOfYear - 1) / 7 + 1;
            return weekOfYear % 2 == 0;
        }

        public List<Assignment> GetByGroupIdAndDate(Guid groupId, DateOnly date)
        {
            logger.Info("GetByGroupIdAndDate method called with GroupId={0}, Date={1}", groupId, date);
            try
            {
                int dayOfWeek = (int)date.DayOfWeek;
                List<Assignment> regularAssignments = assigmentRepository.GetAssignmentsByWeekday(groupId, (Weekday)((dayOfWeek + 6) % 7), AssignmentType.Regular).ToList();
                List<Assignment> intervalAssignments;
                
                if (IsEvenWeek(date))
                {
                    intervalAssignments = assigmentRepository.GetAssignmentsByWeekday(groupId, (Weekday)((dayOfWeek + 6) % 7), AssignmentType.Even).ToList();
                    logger.Info("Assignments for even week found.");
                }
                else
                {
                    intervalAssignments = assigmentRepository.GetAssignmentsByWeekday(groupId, (Weekday)((dayOfWeek + 6) % 7), AssignmentType.Odd).ToList();
                    logger.Info("Assignments for odd week found.");
                }
                
                List<Assignment> specialAssignments = assigmentRepository.GetAssignmentsByDate(groupId, date).ToList();
                regularAssignments.RemoveAll(assignment => specialAssignments.Any(p => p.StartTime == assignment.StartTime));
                
                var result = regularAssignments.Concat(specialAssignments).Concat(intervalAssignments).OrderBy(p => p.StartTime).ToList();
                logger.Info("Assignments retrieved successfully for GroupId={0} and Date={1}, total assignments found: {2}", groupId, date, result.Count);
                return result;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during GetByGroupIdAndDate.");
                throw;
            }
        }

        public Assignment? AddRegularAssignment(
            Weekday weekDay,
            int classNumber,
            Guid classId,
            string? lecturer = null,
            string? address = null,
            string? roomNumber = null,
            ClassType? classType = null,
            Mode? mode = null)
        {
            logger.Info("AddRegularAssignment method called with Weekday={0}, ClassNumber={1}, ClassId={2}", weekDay, classNumber, classId);
            try
            {
                TemplateSlot slot = this.templateSlotRepository.GetByDepartmentIdAndClassNumber(UserSession.currentDepartment.Id, classNumber);
                Assignment? newRegularAssignment = assigmentRepository.AddAssignment(
                    UserSession.currentGroup.Id,
                    classId,
                    weekDay,
                    slot.StartTime,
                    AssignmentType.Regular,
                    lecturer,
                    address,
                    roomNumber,
                    classType,
                    mode,
                    null,
                    slot.EndTime);
                logger.Info("New regular assignment added successfully for ClassId={0}, Weekday={1}, ClassNumber={2}", classId, weekDay, classNumber);
                return newRegularAssignment;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during AddRegularAssignment.");
                throw;
            }
        }

        public Assignment? AddIntervalAssignment(
            Weekday weekDay,
            int classNumber,
            Guid classId,
            AssignmentType assignmentType,
            string? lecturer = null,
            string? address = null,
            string? roomNumber = null,
            ClassType? classType = null,
            Mode? mode = null)
        {
            logger.Info("AddIntervalAssignment method called with Weekday={0}, ClassNumber={1}, ClassId={2}, AssignmentType={3}", weekDay, classNumber, classId, assignmentType);
            try
            {
                TemplateSlot slot = this.templateSlotRepository.GetByDepartmentIdAndClassNumber(UserSession.currentDepartment.Id, classNumber);
                Assignment? newIntervalAssignment = assigmentRepository.AddAssignment(
                    UserSession.currentGroup.Id,
                    classId,
                    weekDay,
                    slot.StartTime,
                    assignmentType,
                    lecturer,
                    address,
                    roomNumber,
                    classType,
                    mode,
                    null,
                    slot.EndTime);
                logger.Info("New interval assignment added successfully for ClassId={0}, Weekday={1}, ClassNumber={2}, AssignmentType={3}", classId, weekDay, classNumber, assignmentType);
                return newIntervalAssignment;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during AddIntervalAssignment.");
                throw;
            }
        }

        public Assignment? AddSpecialAssignment(
            DateOnly date,
            int classNumber,
            Guid classId,
            string? lecturer = null,
            string? address = null,
            string? roomNumber = null,
            ClassType? classType = null,
            Mode? mode = null)
        {
            logger.Info("AddSpecialAssignment method called with Date={0}, ClassNumber={1}, ClassId={2}", date, classNumber, classId);
            try
            {
                TemplateSlot slot = this.templateSlotRepository.GetByDepartmentIdAndClassNumber(UserSession.currentDepartment.Id, classNumber);
                Assignment? newSpecialAssignment = assigmentRepository.AddAssignment(
                    UserSession.currentGroup.Id,
                    classId,
                    (Weekday)(((int)date.DayOfWeek + 6) % 7),
                    slot.StartTime,
                    AssignmentType.Special,
                    lecturer,
                    address,
                    roomNumber,
                    classType,
                    mode,
                    date,
                    slot.EndTime);
                logger.Info("New special assignment added successfully for ClassId={0}, Date={1}, ClassNumber={2}", classId, date, classNumber);
                return newSpecialAssignment;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during AddSpecialAssignment.");
                throw;
            }
        }

        public void Remove(Guid assignmentId)
        {
            logger.Info("Remove method called with AssignmentId={0}", assignmentId);
            try
            {
                assigmentRepository.DeleteAssignment(assignmentId);
                logger.Info("Assignment {0} removed successfully.", assignmentId);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during Remove method.");
                throw;
            }
        }
    }
}
