using Auth.Core.Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthJasonWebToken.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public IRequestBLL RequestBLL;

        public EmployeesController(IRequestBLL requestBLL)
        {
            RequestBLL = requestBLL;
        }

        [HttpGet("getAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await RequestBLL.GetAllEmployees();

            return Ok(employees);
        }
    }
}
