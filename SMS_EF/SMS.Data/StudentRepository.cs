using SMS.Business.Abstraction;
using SMS.Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace SMS.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;
        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public Student AddStu(Student student)
        {
            if (student == null) return null;
            _context.students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student DeleteStu(int id)
        {
            var info = _context.students.Find(id);
            if (info == null) return null;
            _context.students.Remove(info);
            _context.SaveChanges();
            return info;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _context.students.ToList();
        }

        public Student GetStuData(int id)
        {
            var info = _context.students.Find(id);
            if (info == null) return null;
            return info;
        }

        public int UpdateStu(int id, Student student)
        {
            if (student == null || id == null) return -1;
            var found = _context.students.Find(id);
            if (found == null) return 0;
            found.FirstName = student.FirstName;
            found.LastName = student.LastName;
            found.Email = student.Email;
            found.Class = student.Class;
            _context.SaveChanges();
            return 1;
        }

    }
}