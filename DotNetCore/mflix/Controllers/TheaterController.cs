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
    public class TheaterController : ControllerBase
    {
        private readonly TheaterService _service;

        public TheaterController(TheaterService theaterService)
        {
            _service = theaterService;
        }

        [HttpGet]
        public ActionResult<List<Theaters>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetTheater")]
        public ActionResult<Theaters> Get(string id)
        {
            var theater = _service.Get(id);

            if (theater == null)
            {
                return NotFound();
            }
            return Ok(theater);
        }

        [HttpPost]
        public ActionResult<Theaters> Create(Theaters theater)
        {
            _service.Create(theater);

            return CreatedAtRoute("GetTheater", new { id = theater.Id.ToString() }, theater);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Theaters theaterIn)
        {
            var theater = _service.Get(id);

            if (theater == null)
            {
                return NotFound();
            }

            _service.Update(id, theaterIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var theater = _service.Get(id);

            if (theater == null)
            {
                return NotFound();
            }

            _service.Remove(theater.Id);

            return NoContent();
        }


    }
}