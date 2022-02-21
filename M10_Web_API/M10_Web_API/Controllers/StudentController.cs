using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Interfaces.BusinessLogicServices;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("/api/student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentsService studentsService;

        public StudentController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            return studentsService.Get(id) switch
            {
                null => NotFound(),
                var student => student // implicit cast to AcitonResult
            };
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<Student>> GetStudents()
        {
            return studentsService.GetAll().ToArray();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            var newStudentId = studentsService.New(student);
            return Ok($"api/student/{newStudentId}");
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateStudent(int id, Student student)
        {
            var studentId = studentsService.Edit(student with { Id = id });
            return Ok($"api/student/{studentId}");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            studentsService.Delete(id);
            return Ok();
        }
    }
}