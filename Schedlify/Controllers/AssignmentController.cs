using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schedlify.Data;
using Schedlify.Repositories;
using Schedlify.Models;
using Schedlify.Utils;
using Schedlify.Migrations;

namespace Schedlify.Controllers
{
    public class AssignmentController
    {
        private readonly AssignmentsRepository assigmentRepository;
        public AssignmentController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            assigmentRepository = new AssignmentsRepository(_context);
        }
        public bool IsEvenWeek(DateOnly date)
        {
            int weekOfYear = (date.DayOfYear - 1) / 7 + 1;
            return weekOfYear % 2 == 0;
        }
        public IEnumerable<Assignment> GetByGroupIdAndDate(Guid groupId, DateOnly date)
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
        //public Assignment? Add()



    }

}
