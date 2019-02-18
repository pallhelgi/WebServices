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

            if (pageNumber > maxPages || pageNumber < 1)
            {
                // TODO: error handling
                return null;
            }

            //Initiating an empty list of ModelDTO that will be included in the envelope
            List<ModelDTO> modelDTOList = new List<ModelDTO>();

            // 39 models
            // 10 page PageSize
            // 3 page PageNumber
            // ceiling(39 / 10) = 4 models á page
            //   sýna síðu þrjú, eða model frá 2 * 4 + 1 = 9 til og með 3 * 4 = 12

            for (int i = ((pageNumber - 1) * pageSize); i < pageNumber * pageSize; i++)
            {
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
        public IActionResult GetModelById([FromQuery] int Id)
        {
            return Ok();
        }
    }
}