using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TodoApi.DTOs;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodosController(ITodoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _service.GetAll().Select(i => new TodoDto
            {
                Id = i.Id,
                Title = i.Title,
                Description = i.Description,
                IsComplete = i.IsComplete,
                CreatedAt = i.CreatedAt
            });

            return Ok(items);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTodoDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var added = _service.Add(dto);

            var result = new TodoDto
            {
                Id = added.Id,
                Title = added.Title,
                Description = added.Description,
                IsComplete = added.IsComplete,
                CreatedAt = added.CreatedAt
            };

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var item = _service.Get(id);
            if (item == null) return NotFound();

            var dto = new TodoDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsComplete = item.IsComplete,
                CreatedAt = item.CreatedAt
            };

            return Ok(dto);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var ok = _service.Delete(id);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpPost("{id:guid}/toggle")]
        public IActionResult ToggleComplete(Guid id)
        {
            var ok = _service.ToggleComplete(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
