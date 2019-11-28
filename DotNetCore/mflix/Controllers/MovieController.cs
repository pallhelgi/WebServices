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
    public class MovieController : ControllerBase
    {
        private readonly MovieService _service;

        public MovieController(MovieService movieService)
        {
            _service = movieService;
        }

        [HttpGet]
        public ActionResult<List<Movies>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetMovie")]
        public ActionResult<Movies> Get(string id)
        {
            var movie = _service.Get(id);

            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public ActionResult<Movies> Create(Movies movie)
        {
            _service.Create(movie);

            return CreatedAtRoute("GetMovie", new { id = movie.Id.ToString() }, movie);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Movies movieIn)
        {
            var movie = _service.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            _service.Update(id, movieIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var movie = _service.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            _service.Remove(movie.Id);

            return NoContent();
        }
    }
}