using Domain.Interfaces.BusinessLogicServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using System;

namespace M10_Web_API.Controllers
{
    [ApiController]
    [Route("/api/lecture-log")]
    public class LecturesStudentsController : Controller
    {
        private readonly ILecturesStudentsService _lecturesStudentsService;
        ILogger<LecturesStudentsController> _logger;

        public LecturesStudentsController(ILecturesStudentsService lecturesStudentsService, ILogger<LecturesStudentsController> logger)
        {
            _lecturesStudentsService = lecturesStudentsService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<LecturesStudents> GetLogRecord(string id)
        {
            return _lecturesStudentsService.Get(id) switch
            {
                null => NotFound(),
                var lecturesStudent => lecturesStudent  
            };
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<LecturesStudents>> GetLogRecords()
        {
            return _lecturesStudentsService.GetAll().ToArray();
        }

        [HttpPost]
        public IActionResult AddStudent(LecturesStudents lecturesStudent)
        {
            _logger.LogInformation("Adding new leture log");

            var newStudentId = _lecturesStudentsService.New(lecturesStudent);
            return Ok($"api/lecture-log/{newStudentId}");
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateStudent(string id, LecturesStudents lectureStudents)
        {
            var studentId = _lecturesStudentsService.Edit(id, lectureStudents);
            return Ok($"api/lecture-log/{studentId}");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(string id)
        {
            _lecturesStudentsService.Delete(id);
            return Ok();
        }
    }
}