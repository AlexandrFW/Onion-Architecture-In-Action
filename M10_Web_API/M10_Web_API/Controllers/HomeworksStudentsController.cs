using Domain.Interfaces.BusinessLogicServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace M10_Web_API.Controllers
{
    [ApiController]
    [Route("/api/homework-define")]
    public class HomeworksStudentsController : Controller
    {
        private readonly IHomeworksStudentsService _homeworksStudentsService;
        ILogger<HomeworksStudentsController> _logger;

        public HomeworksStudentsController(IHomeworksStudentsService homeworksStudentsService, ILogger<HomeworksStudentsController> logger)
        {
            _homeworksStudentsService = homeworksStudentsService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<HomeworksStudents> GetDefinedHomeworkRecord(string id)
        {
            return _homeworksStudentsService.Get(id) switch
            {
                null => NotFound(),
                var homeworksStudent => homeworksStudent 
            };
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<HomeworksStudents>> GetLogRecords()
        {
            return _homeworksStudentsService.GetAll().ToArray();
        }

        [HttpPost]
        public IActionResult AddStudent(HomeworksStudents homeworksStudent)
        {
            _logger.LogInformation("Define homework to the student");

            var newStudentId = _homeworksStudentsService.New(homeworksStudent);
            return Ok($"api/student/{newStudentId}");
        }

        [HttpPut]
        public ActionResult<string> UpdateStudent(HomeworksStudents homewoksStudents)
        {
            var studentId = _homeworksStudentsService.Edit(homewoksStudents);
            return Ok($"api/student/{studentId}");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(string id)
        {
            _homeworksStudentsService.Delete(id);
            return Ok();
        }
    }
}