using Studentinfo.Models;
using System.Linq.Expressions;

namespace Studentinfo.Data.NewFolder.NewFolder
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        void Add(Student student);
        void Update(Student student);
        void Remove(int id);
        Student Get(int id);
        void Save();
        IEnumerable<Student> FilterBy(string className, string firstName, string lastName);
    }
}
