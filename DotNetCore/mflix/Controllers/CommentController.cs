using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mflix.Models;
using mflix.Services;

namespace mflix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _service;

        public CommentController(CommentService commentService)
        {
            _service = commentService;
        }

        [HttpGet]
        public ActionResult<List<Comments>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetComment")]
        public ActionResult<Comments> Get(string id)
        {
            var comment = _service.Get(id);

            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public ActionResult<Comments> Create(Comments comment)
        {
            _service.Create(comment);

            return CreatedAtRoute("Getcomment", new { id = comment.Id.ToString() }, comment);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Comments commentIn)
        {
            var comment = _service.Get(id);

            if (comment == null)
            {
                return NotFound();
            }

            _service.Update(id, commentIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var comment = _service.Get(id);

            if (comment == null)
            {
                return NotFound();
            }

            _service.Remove(comment.Id);

            return NoContent();
        }
    }
}