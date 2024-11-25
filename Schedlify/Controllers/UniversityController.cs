using NLog;
using Schedlify.Data;
using Schedlify.Repositories;
using Schedlify.Models;


namespace Schedlify.Controllers
{
    public class UniversityController
    {
        private readonly UniversityRepository universityRepository;
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger(); // Initialize NLog logger

        public UniversityController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            universityRepository = new UniversityRepository(_context);
            logger.Info("UniversityController initialized with default DbContext.");
        }

        public UniversityController(ApplicationDbContext context)
        {
            ApplicationDbContext _context = context;
            universityRepository = new UniversityRepository(_context);
            logger.Info("UniversityController initialized with provided DbContext.");
        }

        public List<University> Search(string namePart)
        {
            logger.Info("Search method called with parameter: {0}", namePart);
            try
            {
                var universities = universityRepository.GetByNamePart(namePart);
                logger.Info("Search completed successfully, found {0} universities.", universities.Count());
                return universities.ToList();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during Search.");
                throw;
            }
        }

        public University? Add(string name)
        {
            logger.Info("Add method called with parameter: {0}", name);
            try
            {
                var existingUniversity = universityRepository.GetByName(name);
                if (existingUniversity != null)
                {
                    logger.Warn("University with name '{0}' already exists.", name);
                    return existingUniversity;
                }

                var newUniversity = universityRepository.Add(name);
                logger.Info("University '{0}' added successfully.", name);
                return newUniversity;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during Add.");
                throw;
            }
        }
    }
}
