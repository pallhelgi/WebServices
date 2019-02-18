using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Controllers;
using tinysoldiers.Models;

namespace tinysoldiers.Controllers
{
    public class ModelsController : ControllerBase
    {
        public IActionResult GetAllModels([FromQuery]int pageNumber = 1, [FromQuery]int pageSize = 10)
        {
            return Ok();
        }

        public IActionResult GetModelById([FromQuery] string url)
        {
            return Ok();
        }
    }
}