using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schedlify.Data;
using Schedlify.Repositories;
using Schedlify.Models;
using Schedlify.Global;
using Schedlify.Utils;
using Schedlify.Migrations;
using System.Reflection.Metadata.Ecma335;

namespace Schedlify.Controllers
{
    public class AssignmentController
    {
        private readonly AssignmentsRepository assigmentRepository;
        private readonly TemplateSlotRepository templateSlotRepository;
        public AssignmentController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            this.assigmentRepository = new AssignmentsRepository(_context);
            this.templateSlotRepository = new TemplateSlotRepository(_context);
        }
        public bool IsEvenWeek(DateOnly date)
        {
            int weekOfYear = (date.DayOfYear - 1) / 7 + 1;
            return weekOfYear % 2 == 0;
        }
        public List<Assignment> GetByGroupIdAndDate(Guid groupId, DateOnly date)
        {
            int dayOfWeek = (int)date.DayOfWeek; 
            List<Assignment> regularAssignments = assigmentRepository.GetAssignmentsByWeekday(groupId, (Weekday)((dayOfWeek + 6) % 7), AssignmentType.Regular).ToList();
            List<Assignment> intervalAssignments;
            if (this.IsEvenWeek(date))
            {
                intervalAssignments = assigmentRepository.GetAssignmentsByWeekday(groupId, (Weekday)((dayOfWeek + 6) % 7), AssignmentType.Even).ToList();
            }
            else
            {
                intervalAssignments = assigmentRepository.GetAssignmentsByWeekday(groupId, (Weekday)((dayOfWeek + 6) % 7), AssignmentType.Odd).ToList();
            }
            List<Assignment> specialAssignments = assigmentRepository.GetAssignmentsByDate(groupId, date).ToList();
            regularAssignments.RemoveAll(assignment =>specialAssignments.Any(p => p.StartTime == assignment.StartTime));
            return regularAssignments.Concat(specialAssignments).Concat(intervalAssignments).OrderBy(p => p.StartTime).ToList();


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
            return newRegularAssignment;
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
            TemplateSlot slot = this.templateSlotRepository.GetByDepartmentIdAndClassNumber(UserSession.currentDepartment.Id, classNumber);
            Assignment? newRegularAssignment = assigmentRepository.AddAssignment(
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
            return newRegularAssignment;
        }

        public Assignment? AddSpecialAssignment(
            DateOnly date,
            int classNumber,
            Guid classId,
            AssignmentType assignmentType,
            string? lecturer = null,
            string? address = null,
            string? roomNumber = null,
            ClassType? classType = null,
            Mode? mode = null)
        {
            TemplateSlot slot = this.templateSlotRepository.GetByDepartmentIdAndClassNumber(UserSession.currentDepartment.Id, classNumber);
            Assignment? newRegularAssignment = assigmentRepository.AddAssignment(
                UserSession.currentGroup.Id,
                classId,
                (Weekday)(((int)date.DayOfWeek + 6) % 7),
                slot.StartTime,
                assignmentType,
                lecturer,
                address,
                roomNumber,
                classType,
                mode,
                date,
                slot.EndTime);
            return newRegularAssignment;
        }
        public void delete(Guid assignmentId)
        {
            assigmentRepository.DeleteAssignment(assignmentId);
        }




    }

}
