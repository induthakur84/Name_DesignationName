using Microsoft.EntityFrameworkCore;
using Studentinfo.Data.NewFolder.NewFolder;
using Studentinfo.Models;
using System.Linq.Expressions;



namespace Studentinfo.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<Student> dbSet { get; set; }

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = context.Set<Student>();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public IEnumerable<Student> FilterBy(string className, string firstName, string lastName)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(className))
            {
                query = query.Where(s => s.ClassName.Contains(className));
            }

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(s => s.FirstName.Contains(firstName));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(s => s.LastName.Contains(lastName));
            }

            return query.ToList();
        }

        public Student Get(int id)
        {
            return _context.Find<Student>(id);
        }

        
        public void Save()
        {
            _context.SaveChanges();
        }

       
       

       public void Remove(int id)
        {
            Student entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void Update(Student student)
        {
            _context.Update(student);
        }
    }
}
