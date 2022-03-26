using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sherlock.Apps.Model;
using Sherlock.Apps.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sherlock.Apps.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProperty([FromBody] Property obj)
        {
            var result = await _propertyService.AddAsync(obj);
            if(result)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProperty([FromBody] Property obj)
        {
            var result = await _propertyService.UpdateAsync(obj);
            if(result)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpPost("{propertyId}/Employee/{employeeId}")]
        public async Task<IActionResult> AddEmployee(string propertyId, string employeeId)
        {
            var result = await _propertyService.AssignEmployeeAsync(propertyId, employeeId);
            if(result)
                return Ok(result);
            else
                return BadRequest();
        }

        
    }
}
