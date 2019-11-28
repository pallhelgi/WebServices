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
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService userService)
        {
            _service = userService;
        }

        [HttpGet]
        public ActionResult<List<Users>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<Users> Get(string id)
        {
            var user = _service.Get(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<Users> Create(Users user)
        {
            _service.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Users userIn)
        {
            var user = _service.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _service.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _service.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _service.Remove(user.Id);

            return NoContent();
        }
    }
}