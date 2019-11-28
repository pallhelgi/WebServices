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
    public class SessionController : ControllerBase
    {
        private readonly SessionService _service;

        public SessionController(SessionService sessionService)
        {
            _service = sessionService;
        }

        [HttpGet]
        public ActionResult<List<Sessions>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetSession")]
        public ActionResult<Sessions> Get(string id)
        {
            var session = _service.Get(id);

            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }

        [HttpPost]
        public ActionResult<Sessions> Create(Sessions session)
        {
            _service.Create(session);

            return CreatedAtRoute("GetSession", new { id = session.Id.ToString() }, session);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Sessions sessionIn)
        {
            var session = _service.Get(id);

            if (session == null)
            {
                return NotFound();
            }

            _service.Update(id, sessionIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var session = _service.Get(id);

            if (session == null)
            {
                return NotFound();
            }

            _service.Remove(session.Id);

            return NoContent();
        }
    }
}