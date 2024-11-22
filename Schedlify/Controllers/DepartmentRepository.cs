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
    public class DepartmentController
    {
        private readonly DepartmentRepository departmentRepository;
        public DepartmentController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            departmentRepository = new DepartmentRepository(_context);
        }
        public IEnumerable<Department> Search(Guid universityId,string namePart)
        {
            var departments = departmentRepository.GetByUniversityIdAndNamePart(universityId, namePart);
            return departments;
        }
        public Department? Add(Guid universityId, string namePart)
        {
            var newDepartment = departmentRepository.Add(universityId, namePart);
            return newDepartment;
        }
    }
}
