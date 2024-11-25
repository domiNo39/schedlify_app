using NLog;
using Schedlify.Data;
using Schedlify.Models;
using Schedlify.Repositories;


namespace Schedlify.Controllers
{
    public class DepartmentController
    {
        private readonly DepartmentRepository departmentRepository;
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger(); // Initialize NLog logger

        public DepartmentController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            departmentRepository = new DepartmentRepository(_context);
            logger.Info("DepartmentController initialized with default DbContext.");
        }

        public DepartmentController(ApplicationDbContext context)
        {
            ApplicationDbContext _context = context;
            departmentRepository = new DepartmentRepository(_context);
            logger.Info("DepartmentController initialized with provided DbContext.");
        }

        public List<Department> Search(Guid universityId, string namePart)
        {
            logger.Info("Search method called with parameters: UniversityId={0}, NamePart={1}", universityId, namePart);
            try
            {
                var departments = departmentRepository.GetByNamePartAndUniversityId(universityId, namePart);
                logger.Info("Search completed successfully, found {0} departments.", departments.Count());
                return departments.ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during Search.");
                throw;
            }
        }

        public Department? Add(Guid universityId, string name)
        {
            logger.Info("Add method called with parameters: UniversityId={0}, Name={1}", universityId, name);
            try
            {
                var existingDepartment = departmentRepository.GetByNameAndUniversityId(universityId, name);
                if (existingDepartment != null)
                {
                    logger.Warn("Department with name '{0}' already exists under UniversityId {1}.", name, universityId);
                    return existingDepartment;
                }

                var newDepartment = departmentRepository.Add(universityId, name);
                logger.Info("Department '{0}' added successfully under UniversityId {1}.", name, universityId);
                return newDepartment;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during Add.");
                throw;
            }
        }
    }
}
