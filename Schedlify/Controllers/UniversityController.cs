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
    public class UniversityController
    {
        private readonly UniversityRepository universityRepository;
        public UniversityController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            universityRepository = new UniversityRepository(_context);
        }
        public UniversityController(ApplicationDbContext context)
        {
            ApplicationDbContext _context = context;
            universityRepository = new UniversityRepository(_context);
        }
        public List<University> Search(string namePart)
        {
            var universities = universityRepository.GetByNamePart(namePart);
            return universities.ToList();
        }

        public University? Add(string name)
        {
            var existingUniversity = universityRepository.GetByName(name);
            if (existingUniversity != null)
            {
                return existingUniversity;
            }

            var newUniversity = universityRepository.Add(name);

            return newUniversity; 
        }
    }
}