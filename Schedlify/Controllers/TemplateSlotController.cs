using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schedlify.Data;
using Schedlify.Repositories;
using Schedlify.Models;

namespace Schedlify.Controllers
{
    public class TemplateSlotController
    {
        private readonly TemplateSlotRepository templateSlotRepository;
        public TemplateSlotController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            templateSlotRepository = new TemplateSlotRepository(_context);
        }
        public IEnumerable<TemplateSlot> GetByDepartmentId(Guid departmentId)
        {
            var templateSlots = templateSlotRepository.GetByDepartmentId(departmentId)
            return templateSlots;
        }

        public TemplateSlot? GetByDepartmentId(Guid departmentId)
        {
            var newUniversity = templateSlotRepository.GetByDepartmentId(departmentId);
            return newUniversity; 
        }



    }
}
