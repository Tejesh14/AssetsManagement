using AssetManagementWebAPI.Business_Logic_Layer.Interfaces;
using AssetManagementWebAPI.Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagementWebAPI.Presentation_Layer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SoftwareController : ControllerBase
    {
        private readonly ISoftwareService _softwareService;
        public SoftwareController(ISoftwareService softwareService)
        {
            _softwareService = softwareService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Software>>> Get()
        {
            try
            {
                return Ok(await _softwareService.Display());
            }
            catch
            {
                return NotFound("Data not found");
            }
        }

        [Route("{id}")]
        [HttpPatch]
        public async Task<ActionResult<Software>> UnAssign(int id)
        {
            try
            {
                return Ok(await _softwareService.UnAssign(id));
            }
            catch
            {
                return NotFound("Data not found");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Software>> AddSoftware(Software Software)
        {
            try
            {
                return Ok(await _softwareService.AddSoftware(Software));
            }
            catch
            {
                return NotFound("Data not created");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Software>> Delete(int id)
        {
            try
            {
                return Ok(await _softwareService.Delete(id));
            }
            catch
            {
                return BadRequest("Not deleted");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Software>> Update(int id, Software Software)
        {
            try
            {
                return Ok(await _softwareService.Update(id, Software));
            }
            catch
            {
                return BadRequest("Not Updated");
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<Software>> Assign(int id, string userName)
        {
            var data = await _softwareService.Assign(id, userName);
            if(data.AssignTo == userName)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("Asset already assigned");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Software>> Search(int id)
        {
            try
            {
                return Ok(await _softwareService.Search(id));
            }
            catch
            {
                return NotFound("Not found");
            }
        }
    }
}
