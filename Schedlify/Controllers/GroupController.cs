using NLog;
using Schedlify.Data;
using Schedlify.Models;
using Schedlify.Repositories;


namespace Schedlify.Controllers
{
    public class GroupController
    {
        private readonly GroupRepository groupRepository;
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger(); // Initialize NLog logger

        public GroupController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            groupRepository = new GroupRepository(_context);
            logger.Info("GroupController initialized with default DbContext.");
        }

        public GroupController(ApplicationDbContext context)
        {
            ApplicationDbContext _context = context;
            groupRepository = new GroupRepository(_context);
            logger.Info("GroupController initialized with provided DbContext.");
        }

        public List<Group> Search(Guid departmentId, string namePart)
        {
            logger.Info("Search method called with parameters: DepartmentId={0}, NamePart={1}", departmentId, namePart);
            try
            {
                var groups = groupRepository.GetByNamePartAndDepartmentId(namePart, departmentId);
                logger.Info("Search completed successfully, found {0} groups.", groups.Count());
                return groups.ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during Search.");
                throw;
            }
        }

        public Group? Add(Guid departmentId, Guid administratorId, string name)
        {
            logger.Info("Add method called with parameters: DepartmentId={0}, AdministratorId={1}, Name={2}", departmentId, administratorId, name);
            try
            {
                var newGroup = groupRepository.Add(departmentId, administratorId, name);
                logger.Info("Group '{0}' added successfully under DepartmentId {1} with AdministratorId {2}.", name, departmentId, administratorId);
                return newGroup;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during Add.");
                throw;
            }
        }

        public Group? GetByAdministratorId(Guid administratorId)
        {
            logger.Info("GetByAdministratorId method called with parameter: AdministratorId={0}", administratorId);
            try
            {
                var group = groupRepository.GetByAdministratorId(administratorId);
                if (group != null)
                {
                    logger.Info("Group found for AdministratorId {0}.", administratorId);
                }
                else
                {
                    logger.Warn("No group found for AdministratorId {0}.", administratorId);
                }
                return group;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during GetByAdministratorId.");
                throw;
            }
        }
    }
}
