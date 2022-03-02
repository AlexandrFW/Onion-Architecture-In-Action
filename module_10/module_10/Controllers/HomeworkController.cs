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
        public ActionResult<Homework> GetHomework(int id)
        {
            return _homeworksService.Get(id) switch
            {
                null => NotFound(),
                var homework => homework  
            };
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<Homework>> GetHomeworks()
        {
            var homeworks = _homeworksService.GetAll().ToArray();

            if (!homeworks.Any())
            {
                return NotFound();
            }

            return Ok(homeworks);
        }

        [HttpPost]
        public IActionResult AddHomework(Homework homework)
        {
            _logger.LogInformation("Adding new homework");

            var newHomeworkId = _homeworksService.New(homework);
            return Ok($"api/homework/{newHomeworkId}");
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateHomework(int id, Homework student)
        {
            var homeworkId = _homeworksService.Edit(id, student);
            return Ok($"api/homework/{homeworkId}");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            _homeworksService.Delete(id);
            return Ok();
        }
    }
}