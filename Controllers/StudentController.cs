using Microsoft.AspNetCore.Mvc;
using SchoolDbCoreWebAPI.Models;

namespace SchoolDbCoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public StudentController(SchoolDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }

        
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok("Student added successfully");
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.StudentId == id);

            if (existingStudent == null)
                return NotFound("Student not found");

            existingStudent.Name = student.Name;
            existingStudent.RollNumber = student.RollNumber;
            existingStudent.GradeId = student.GradeId;

            _context.SaveChanges();

            return Ok("Student updated successfully");
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
                return NotFound("Student not found");

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Ok("Student deleted successfully");
        }
    }
}