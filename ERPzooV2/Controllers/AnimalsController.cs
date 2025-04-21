using System;
using System.Runtime.InteropServices;
using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalManagementService _mgr;
        private readonly IAnimalTransferService _transfer;

        public AnimalsController(
            IAnimalManagementService mgr,
            IAnimalTransferService transfer)
        {
            _mgr = mgr;
            _transfer = transfer;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_mgr.GetAll());

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id) => Ok(_mgr.Get(id));

        [HttpPost]
        public IActionResult Create([FromBody] CreateAnimalRequest req)
        {
            var a = _mgr.Create(req);
            return CreatedAtAction(nameof(Get), new { id = a.Id }, a);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _mgr.Delete(id);
            return NoContent();
        }

        [HttpPost("{id:guid}/transfer")]
        public IActionResult Transfer(Guid id, [FromBody] TransferAnimalRequest req)
        {
            if (id != req.AnimalId)
                return BadRequest("ID mismatch");
            _transfer.Transfer(req);
            return NoContent();
        }
    }
}
