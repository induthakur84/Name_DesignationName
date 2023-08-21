using Studentinfo.Models;
using System.Linq.Expressions;

namespace Studentinfo.Data.NewFolder.NewFolder
{
    public interface IStudentRepository
    {
        Student Get(int id); // for find id and return class
        IEnumerable<Student> GetAll(                         //this is for display
            Expression<Func<Student, bool>> filter = null,
        Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null,
            string includeProperties = null);
    }
}
