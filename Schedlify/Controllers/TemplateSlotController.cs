using NLog;
using Schedlify.Data;
using Schedlify.Models;
using Schedlify.Repositories;
using Schedlify.Utils;


namespace Schedlify.Controllers
{
    public class TemplateSlotController
    {
        private readonly TemplateSlotRepository templateSlotRepository;
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger(); // Initialize NLog logger

        public TemplateSlotController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            templateSlotRepository = new TemplateSlotRepository(_context);
            logger.Info("TemplateSlotController initialized with default DbContext.");
        }

        public TemplateSlotController(ApplicationDbContext context)
        {
            ApplicationDbContext _context = context;
            templateSlotRepository = new TemplateSlotRepository(_context);
            logger.Info("TemplateSlotController initialized with provided DbContext.");
        }

        public List<TemplateSlot> GetByDepartmentId(Guid departmentId)
        {
            logger.Info("GetByDepartmentId method called with DepartmentId={0}", departmentId);
            try
            {
                var templateSlots = templateSlotRepository.GetByDepartmentId(departmentId);
                logger.Info("GetByDepartmentId completed successfully, found {0} template slots.", templateSlots.Count());
                return templateSlots.ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during GetByDepartmentId.");
                throw;
            }
        }

        public void AddTemplateSlots(Guid departmentId, List<Slot> slotList)
        {
            logger.Info("AddTemplateSlots method called with DepartmentId={0}, SlotCount={1}", departmentId, slotList.Count);
            try
            {
                int i = 0;
                slotList = slotList.OrderBy(p => p.startTime).ToList();
                foreach (Slot slot in slotList)
                {
                    templateSlotRepository.Add(departmentId, slot.startTime, slot.endTime, i);
                    i++;
                    logger.Info("TemplateSlot added for DepartmentId={0}, StartTime={1}, EndTime={2}, Index={3}", departmentId, slot.startTime, slot.endTime, i);
                }
                logger.Info("{0} template slots added successfully for DepartmentId={1}.", slotList.Count, departmentId);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during AddTemplateSlots.");
                throw;
            }
        }
    }
}
