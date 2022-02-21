using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces.BusinessLogicServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("/api/homework")]
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworksService _homeworksService;
        ILogger<HomeworkController> _logger;

        public HomeworkController(IHomeworksService homeworksService, ILogger<HomeworkController> logger)
        {
           _homeworksService  = homeworksService;
           _logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<Homework> GetStudent(int id)
        {
            return _homeworksService.Get(id) switch
            {
                null => NotFound(),
                var student => student // implicit cast to AcitonResult
            };
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<Homework>> GetStudents()
        {
            return _homeworksService.GetAll().ToArray();
        }

        [HttpPost]
        public IActionResult AddStudent(Homework student)
        {
            _logger.LogInformation("Adding new homework");

            var newStudentId = _homeworksService.New(student);
            return Ok($"api/student/{newStudentId}");
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateStudent(int id, Homework student)
        {
            var studentId = _homeworksService.Edit(student with { Id = id });
            return Ok($"api/student/{studentId}");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            _homeworksService.Delete(id);
            return Ok();
        }
    }
}