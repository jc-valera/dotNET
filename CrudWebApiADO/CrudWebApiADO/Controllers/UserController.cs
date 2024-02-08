using Jcvalera.Common.Core.BLL;
using Jcvalera.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Security.Principal;

namespace CrudWebApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserBLL userBLL;

        public UserController()
        {
            userBLL = new UserBLL();
        }

        [HttpGet]
        [Route("UserExist")]
        public async Task<ActionResult> ExistUser(int id)
        {
            var userExist = await userBLL.ExistUser(id);

            return Ok(userExist);
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await userBLL.GetUsers();

            return Ok(users);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<List<User>>> CreateUser(User user)
        {
            var users = await userBLL.CreateUser(user);

            return Ok(users);
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, User user)
        {
            var users = await userBLL.UpdateUser(id, user);

            return Ok(users);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var users = await userBLL.DeleteUser(id);

            return Ok(users);
        }

    }
}
