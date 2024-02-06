using Jcvalera.Common.DataAccess.SqlServer;
using Jcvalera.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace CrudWebApiEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public SqlServerDAL Context;

        public UserController(SqlServerDAL context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await Context.Users.ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var userExist = await Context.Users.FindAsync(id);

            if (userExist is null)
                return NotFound("The user does not exist");

            return Ok(userExist);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            Context.Users.Add(user);

            await Context.SaveChangesAsync();

            var users = await Context.Users.ToListAsync();

            return Ok(users);
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User user)
        {
            var userExist = await Context.Users.FindAsync(user.Id);

            if (userExist is null)
                return NotFound("The user does not exist");

            userExist.Name = user.Name;
            userExist.LastName = user.LastName;
            userExist.Age = user.Age;
            userExist.BirthDate = user.BirthDate;

            await Context.SaveChangesAsync();

            var users = await Context.Users.ToListAsync();

            return Ok(users);
        }

        [HttpDelete]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var userExist = await Context.Users.FindAsync(id);

            if (userExist is null)
                return NotFound("The user does not exist");

            Context.Users.Remove(userExist);

            await Context.SaveChangesAsync();

            var users = await Context.Users.ToListAsync();

            return Ok(users);
        }

    }
}
