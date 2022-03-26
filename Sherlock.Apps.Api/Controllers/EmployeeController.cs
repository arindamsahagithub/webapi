using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sherlock.Apps.Model;
using Sherlock.Apps.Service.Contract;

namespace Sherlock.Apps.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee obj)
        {
            var result = await _employeeService.AddAsync(obj);
            if(result)
                return Ok(result);
            else
                return BadRequest();
        }
    }
}