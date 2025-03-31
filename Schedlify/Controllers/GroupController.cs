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
        public GroupController(ApplicationDbContext context)
        {
            ApplicationDbContext _context = context;
            groupRepository = new GroupRepository(_context);
        }
        public List<Group> Search(Guid departmentId,string namePart)
        {
            var groups = groupRepository.GetByNamePartAndDepartmentId(namePart, departmentId);
            return groups.ToList();
        }
        public Group? Add(Guid departmentId, Guid administratorId, string name)
        {
            var newGroup = groupRepository.Add(departmentId, administratorId, name);
            return newGroup;
        }
        public Group? GetByAdministratorId(Guid administratorId)
        {
            var group = groupRepository.GetByAdministratorId(administratorId);
            return group;
        }
    }
}
