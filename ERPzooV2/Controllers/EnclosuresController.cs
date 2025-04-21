using System;
using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnclosuresController : ControllerBase
    {
        private readonly IEnclosureManagementService _mgr;

        public EnclosuresController(IEnclosureManagementService mgr)
        {
            _mgr = mgr;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_mgr.GetAll());

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id) => Ok(_mgr.Get(id));

        [HttpPost]
        public IActionResult Create([FromBody] CreateEnclosureRequest req)
        {
            var e = _mgr.Create(req);
            return CreatedAtAction(nameof(Get), new { id = e.Id }, e);
        }

        [HttpPost("{id:guid}/animals")]
        public IActionResult AddAnimal(Guid id, [FromBody] AddAnimalToEnclosureRequest req)
        {
            _mgr.AddAnimalToEnclosure(id, req.AnimalId);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _mgr.Delete(id);
            return NoContent();
        }

        [HttpPost("{id:guid}/clean")]
        public IActionResult Clean(Guid id)
        {
            _mgr.Clean(id);
            return NoContent();
        }
    }
}
