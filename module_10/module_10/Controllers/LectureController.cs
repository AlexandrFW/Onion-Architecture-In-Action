using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Interfaces.BusinessLogicServices;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("/api/lecture")]
    public class LectureController : ControllerBase
    {
        private readonly ILecturesService _lecturesService;

        public LectureController(ILecturesService lecturesService)
        {
            _lecturesService = lecturesService;
        }

        [HttpGet("{id}")]
        public ActionResult<Lecture> GetLector(int id)
        {
            return _lecturesService.Get(id) switch
            {
                null => NotFound(),
                var lecture => lecture  
            };
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<Lecture>> GetLectors()
        {
            return _lecturesService.GetAll().ToArray();
        }

        [HttpPost]
        public IActionResult AddLector(Lecture lecture)
        {
            var newLectorId = _lecturesService.New(lecture);
            return Ok($"api/lector/{newLectorId}");
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateLecture(int id, Lecture lecture)
        {
            var lectureId = _lecturesService.Edit(lecture with { Id = id });
            return Ok($"api/lector/{lectureId}");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteLector(int id)
        {
            _lecturesService.Delete(id);
            return Ok();
        }
    }
}