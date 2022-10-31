using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Business.Abstraction;
using SMS.Business.Entities;

namespace SMS.Client.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;

        public StudentController(IStudentRepository repo)
        {
            this._repo = repo;
        }

        // GET: StudentController
        [HttpGet]
        public ActionResult<Student> GetAllStudent()
        {
            var found = _repo.GetAllStudent();
            if (found == null) return NotFound();
            return Ok(_repo.GetAllStudent());
        }

        // GET: StudentController/GetStudentById/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var found = _repo.GetStuData(id);
            if (found == null)return NotFound();
            return Ok(_repo.GetStuData(id));
        }

        // POST: StudentController/AddStudent
        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            var result = _repo.AddStu(student);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        // PUT: StudentController/UpdateStudent/5
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            var result = _repo.UpdateStu(id, student);
            if (result == -1) return BadRequest();
            if (result == 0) return NotFound();
            return NoContent();
        }

        // DELETE: StudentController/DeleteStudent/5
        [HttpDelete("{id}")]
        public ActionResult<Student> DeleteStudent(int id)
        {
            var found = _repo.DeleteStu(id);
            if (found == null) return NotFound();
            return NoContent();
        }
    }
}
