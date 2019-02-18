using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Linq;
using tinysoldiers.Models;
using tinysoldiers.Data;
using System.Collections.Generic;
using tinysoldiers.Extensions;

namespace tinysoldiers.Controllers
{
    [Route("api/models")]
    public class ModelsController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult GetAllModels([FromQuery]int pageNumber = 1, [FromQuery]int pageSize = 10)
        {
            double maxPages = Math.Ceiling(DataContext.Models.Count / (double)pageSize);

            // PageNumber can not be higher than maximum number of pages
            // Page number can not be less than 1
            if (pageNumber > maxPages || pageNumber < 1)
            {
                // TODO: error handling
                return BadRequest();
            }

            // Initiating an empty list of ModelDTO that will be included in the envelope
            List<ModelDTO> modelDTOList = new List<ModelDTO>();

            // Adding the correct page to a ModelDTO list to be added to the envelope
            for (int i = ((pageNumber - 1) * pageSize); i < pageNumber * pageSize; i++)
            {
                // ToLightWeight changed Model to ModelDTO
                modelDTOList.Add(DataContext.Models.ToLightWeight()[i]);
            }

            Envelope<ModelDTO> env = new Envelope<ModelDTO>();
            env.Items = modelDTOList;
            env.PageNumber = pageNumber;
            env.PageSize = pageSize;
            env.MaxPages = (int)maxPages;

            return Ok(env);
        }

        [HttpGet("{Id:int}")]
        public IActionResult GetModelById(int Id)
        {
            List<ModelDetailsDTO> model = DataContext.Models.FindAll(x => x.Id == Id).ToDetails();
            if (model.Count == 0)
            {
                return BadRequest();
            }
            return Ok(model[0]);
        }
    }
}