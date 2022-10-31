using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Business.Entities;

namespace SMS.Business.Abstraction
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAllStudent();
        public Student AddStu(Student student);
        public int UpdateStu(int id, Student student);
        public Student GetStuData(int id);
        public Student DeleteStu(int id);
    }
}
