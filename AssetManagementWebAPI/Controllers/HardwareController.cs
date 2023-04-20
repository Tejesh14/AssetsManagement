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
    public class HardwareController : ControllerBase
    {
        private readonly IHardwareService _hardwareService;
        public HardwareController(IHardwareService hardwareService)
        {
            _hardwareService = hardwareService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hardware>>> Get()
        {
            try
            {
                return Ok(await _hardwareService.Display());
            }
            catch
            {
                return NotFound("Data not found");
            }
        }

        [Route("{id}")]
        [HttpPatch]
        public async Task<ActionResult<Hardware>> UnAssign(int id)
        {
            try
            {
                return Ok(await _hardwareService.UnAssign(id));
            }
            catch
            {
                return NotFound("Data not found");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Hardware>> AddHardware(Hardware Hardware)
        {
            try
            {
                return Ok(await _hardwareService.AddHardware(Hardware));
            }
            catch
            {
                return NotFound("Data not created");
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Hardware>> Delete(int id)
        {
            try
            {
                return Ok(await _hardwareService.Delete(id));
            }
            catch
            {
                return BadRequest("Not deleted");
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Hardware>> Update(int id, Hardware Hardware)
        {
            try
            {
                return Ok(await _hardwareService.Update(id, Hardware));
            }
            catch
            {
                return BadRequest("Not Updated");
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<Hardware>> Assign(int id, string userName)
        {
            var data = await _hardwareService.Assign(id, userName);
            if (data.AssignTo == userName)
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
        public async Task<ActionResult<Hardware>> Search(int id)
        {
            try
            {
                return Ok(await _hardwareService.Search(id));
            }
            catch
            {
                return NotFound("Not found");
            }
        }
    }
}
