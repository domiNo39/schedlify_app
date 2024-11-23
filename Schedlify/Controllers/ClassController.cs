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
    public class ClassController
    {
        private readonly ClassRepository classRepository;
        public ClassController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            classRepository = new ClassRepository(_context);
        }
        public IEnumerable<Class> GetByGroupId(Guid groupId)
        {
            var templateSlots = classRepository.GetByGroupId(groupId);
            return templateSlots;
        }

        public Class? Add(Guid groupId, string name)
        {

            var newClass=classRepository.Add(groupId,name);
            return newClass;
        }
        public Class? Edit(Guid classId, string name)
        {

            var editedClass = classRepository.EditById(classId, name);
            return editedClass;
        }
        public bool Delete(Guid classId)
        {
            return classRepository.Remove(classId);
        }



    }

}
