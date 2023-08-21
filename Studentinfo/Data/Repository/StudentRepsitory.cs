using Microsoft.EntityFrameworkCore;
using Studentinfo.Data.NewFolder.NewFolder;
using Studentinfo.Models;

namespace Studentinfo.Data.Repository
{
    public class StudentRepsitory: IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<Student> dbSet;
        public StudentRepsitory(ApplicationDbContext context) 
        {
            _context = context;
        }

        public Student Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<Student> GetAll(Expression<Func<Student, bool>> filter = null, Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null, string includeProperties = null)
        {
            throw new NotImplementedException();
        }
    }
}
