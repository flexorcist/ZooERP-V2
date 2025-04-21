using System;
using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpeciesController : ControllerBase
    {
        private readonly ISpeciesService _svc;
        public SpeciesController(ISpeciesService svc) => _svc = svc;

        [HttpGet]
        public IActionResult GetAll() => Ok(_svc.GetAll());

        [HttpPost]
        public IActionResult Register([FromBody] RegisterSpeciesRequest req)
        {
            _svc.Register(req.SpeciesName, req.IsHerbivore);
            return NoContent();
        }
    }
}
