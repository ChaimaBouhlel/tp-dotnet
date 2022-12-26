using System.Linq.Expressions;
using tp4.Models;

namespace tp4.Data
{
    public interface IStudentRepository<Student> where Student:class
    {
        Student GetStudent(int id);
        IEnumerable<Student> GetAll();
        IEnumerable<Student> Find(Expression<Func<Student,bool>> predicate);
        bool Add(Student student);
        bool Remove(Student student);
    }
    public class StudentRepository: IStudentRepository<Student>
    {
        private readonly UniversityContext _universityContext;

        public StudentRepository(UniversityContext universityContext)
        {
            _universityContext = universityContext;
        }

        public bool Add(Student student)
        {
            try
            {
                _universityContext.Set<Student>().Add(student);
                _universityContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            try
            {
                return _universityContext.Set<Student>().Where(predicate);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Student> GetAll()
        {
            try
            {
                return _universityContext.Set<Student>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Student GetStudent(int id)
        {
            try
            {
                return _universityContext.Set<Student>().Find(id);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public IEnumerable<String> GetCourses()
        {
            return _universityContext.Student.Select(s => s.course).Distinct().ToList();
        }

        public bool Remove(Student student)
        {
            try
            {
                _universityContext.Set<Student>().Remove(student);
                _universityContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
