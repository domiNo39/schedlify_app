using Schedlify.Data;
using Schedlify.Models;
using Schedlify.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedlify.Controllers
{
    public class GroupController
    {
        private readonly GroupRepository groupRepository;
        public GroupController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            groupRepository = new GroupRepository(_context);
        }
        public IEnumerable<Group> Search(Guid departmentId,string namePart)
        {
            var groups = groupRepository.GetByNamePartAndDepartmentId(namePart, departmentId);
            return groups;
        }
        public Group? Add(Guid departmentId, Guid administratorId, string namePart)
        {
            var newGroup = groupRepository.Add(departmentId, administratorId, namePart);
            return newGroup;
        }
    }
}
