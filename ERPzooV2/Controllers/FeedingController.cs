using System;
using System.Linq;
using Application.DTOs;
using Application.Services;
using AutoMapper;
using Domain.Feeding;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedingController : ControllerBase
    {
        private readonly IFeedingOrganizationService _svc;
        private readonly IFeedingScheduleRepository _repo;
        private readonly IMapper _mapper;

        public FeedingController(
            IFeedingOrganizationService svc,
            IFeedingScheduleRepository repo,
            IMapper mapper)
        {
            _svc = svc;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var all = _repo.ListAll()
                           .Select(f => _mapper.Map<FeedingScheduleDto>(f));
            return Ok(all);
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var f = _repo.GetById(FeedingScheduleId.From(id));
            return Ok(_mapper.Map<FeedingScheduleDto>(f));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateFeedingScheduleRequest req)
        {
            var f = _svc.Schedule(req);
            return CreatedAtAction(nameof(Get), new { id = f.Id }, f);
        }

        [HttpPut("{id:guid}/done")]
        public IActionResult MarkDone(Guid id)
        {
            _svc.MarkAsDone(id);
            return NoContent();
        }

        [HttpPut("{id:guid}/reschedule")]
        public IActionResult Reschedule(Guid id, [FromBody] DateTimeOffset newTime)
        {
            _svc.Reschedule(id, newTime);
            return NoContent();
        }
    }
}
