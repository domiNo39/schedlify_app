using NLog; // Import NLog
using Schedlify.Data;
using Schedlify.Models;
using Schedlify.Repositories;


namespace Schedlify.Controllers
{
    public class ClassController
    {
        private readonly ClassRepository classRepository;
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger(); // Initialize NLog logger

        public ClassController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            classRepository = new ClassRepository(_context);
            logger.Info("ClassController initialized with default DbContext.");
        }

        public ClassController(ApplicationDbContext context)
        {
            ApplicationDbContext _context = context;
            classRepository = new ClassRepository(_context);
            logger.Info("ClassController initialized with provided DbContext.");
        }

        public List<Class> GetByGroupId(Guid groupId)
        {
            logger.Info("GetByGroupId method called with GroupId={0}", groupId);
            try
            {
                var classes = classRepository.GetByGroupId(groupId);
                logger.Info("GetByGroupId completed successfully, found {0} classes.", classes.Count());
                return classes.ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during GetByGroupId.");
                throw;
            }
        }

        public Class? Add(Guid groupId, string name)
        {
            logger.Info("Add method called with GroupId={0}, Name={1}", groupId, name);
            try
            {
                var newClass = classRepository.Add(groupId, name);
                logger.Info("Class added successfully for GroupId={0}, Name={1}", groupId, name);
                return newClass;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during Add method.");
                throw;
            }
        }

        public Class? Edit(Guid classId, string name)
        {
            logger.Info("Edit method called with ClassId={0}, Name={1}", classId, name);
            try
            {
                var editedClass = classRepository.EditById(classId, name);
                logger.Info("Class edited successfully for ClassId={0}, Name={1}", classId, name);
                return editedClass;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during Edit method.");
                throw;
            }
        }

        public bool Delete(Guid classId)
        {
            logger.Info("Delete method called with ClassId={0}", classId);
            try
            {
                var isDeleted = classRepository.Remove(classId);
                logger.Info("Class {0} deleted successfully.", classId);
                return isDeleted;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during Delete method.");
                throw;
            }
        }
    }
}
