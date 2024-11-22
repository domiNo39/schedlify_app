using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schedlify.Data;
using Schedlify.Repositories;
using Microsoft.AspNetCore.Identity.Data;
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
        public IEnumerable<University> Search(string namePart)
        {
            var universities = universityRepository.GetByNamePart(namePart);
            return universities;
        }

        public University? Add(string name)
        {
            var existingUniversity = universityRepository.GetByName(name);
            if (existingUniversity != null)
            {
                return null;
            }

            var newUniversity = universityRepository.Add(name);

            return newUniversity; 
        }



    }
}
