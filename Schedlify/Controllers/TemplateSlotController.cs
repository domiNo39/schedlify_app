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
        public TemplateSlotController(ApplicationDbContext context)
        {
            ApplicationDbContext _context = context;
            templateSlotRepository = new TemplateSlotRepository(_context);
        }
        public List<TemplateSlot> GetByDepartmentId(Guid departmentId)
        {
            var templateSlots = templateSlotRepository.GetByDepartmentId(departmentId);
            return templateSlots.ToList();
        }

        public void AddTemplateSlots(Guid departmentId, List<Slot> slotList)
        {
            int i = 0;
            slotList=slotList.OrderBy(p => p.startTime).ToList();
            foreach (Slot slot in slotList)
            {
                templateSlotRepository.Add(departmentId, slot.startTime, slot.endTime, i);
                i++;
            }
        }



    }
}
