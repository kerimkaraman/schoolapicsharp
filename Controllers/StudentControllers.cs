using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SchoolAPI.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly List<Student> _students;

        public StudentsController()
        {
            _students = new List<Student>
            {
                new Student { Id = 1, Name = "Kerim", Grade = "A" },
                new Student { Id = 2, Name = "Furkan", Grade = "B" },
                new Student { Id = 3, Name = "Mustafa", Grade = "C" }
            };
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(_students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _students.Find(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _students.Add(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student updatedStudent)
        {
            var index = _students.FindIndex(s => s.Id == id);
            if (index == -1)
            {
                return NotFound();
            }
            _students[index] = updatedStudent;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _students.Find(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            _students.Remove(student);
            return NoContent();
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
    }
}
