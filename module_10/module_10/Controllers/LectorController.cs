using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using Domain.Interfaces.BusinessLogicServices;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("/api/lector")]
    public class LectorController : ControllerBase
    {
        private readonly ILectorsService _lectorsService;

        public LectorController(ILectorsService lectorsService)
        {
            _lectorsService = lectorsService;
        }

        [HttpGet("{id}")]
        public ActionResult<Lector> GetLector(int id)
        {
            return _lectorsService.Get(id) switch
            {
                null => NotFound(),
                var lector => lector  
            };
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<Lector>> GetLectors()
        {
            return _lectorsService.GetAll().ToArray();
        }

        [HttpPost]
        public IActionResult AddLector(Lector lector)
        {
            var newLectorId = _lectorsService.New(lector);
            return Ok($"api/lector/{newLectorId}");
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateLector(int id, Lector lector)
        {
            var lectorId = _lectorsService.Edit(lector with { Id = id });
            return Ok($"api/lector/{lectorId}");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteLector(int id)
        {
            _lectorsService.Delete(id);
            return Ok();
        }
    }
}