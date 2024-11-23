using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schedlify.Data;
using Schedlify.Repositories;
using Schedlify.Models;
using Schedlify.Utils;

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
            var templateSlots = templateSlotRepository.GetByDepartmentId(departmentId);
            return templateSlots;
        }

        public IEnumerable<TemplateSlot> AddTemplateSlots(Guid departmentId, IEnumerable<Slot> slotList)
        {
            List<TemplateSlot> templateSlots = new List<TemplateSlot>();
            foreach (var slot in slotList)
            {
                templateSlots.Append(templateSlotRepository.Add(departmentId, slot.startTime, slot.endTime, slot.classNumber));
            }
            return templateSlots;
        }



    }
}
