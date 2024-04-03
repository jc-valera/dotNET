using Auth.Core.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthJasonWebToken.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public RequestBLL RequestBLL;

        public EmployeesController()
        {
            RequestBLL = new RequestBLL();
        }

        [HttpGet("getAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await RequestBLL.GetAllEmployees();

            return Ok(employees);
        }
    }
}
