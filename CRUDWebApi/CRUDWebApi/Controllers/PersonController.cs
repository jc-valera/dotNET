using CRUDWebApi.Core;
using CRUDWebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext Context;

        public PersonController(DataContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPerson()
        {
            var persons = await Context.Persons.ToListAsync();

            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await Context.Persons.FindAsync(id);

            if (person is null)
                return NotFound("The person does not exist.");

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> AddPerson(Person person)
        {
            Context.Persons.Add(person);

            await Context.SaveChangesAsync();

            var persons = await Context.Persons.ToListAsync();

            return Ok(persons);
        }

        [HttpPut]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person personRequest)
        {
            var personExist = await Context.Persons.FindAsync(personRequest.Id);
            if (personExist is null)
                return NotFound("The person doest not exist.");

            personExist.Name = personRequest.Name;
            personExist.LastName = personRequest.LastName;
            personExist.Age = personRequest.Age;

            await Context.SaveChangesAsync();

            var persons = await Context.Persons.ToListAsync();

            return Ok(persons);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Person>>> DeletePerson(int id)
        {
            var personExist = await Context.Persons.FindAsync(id);
            if (personExist is null)
                return NotFound("The person does not exist");

            Context.Persons.Remove(personExist);
            
            await Context.SaveChangesAsync();

            var persons = await Context.Persons.ToListAsync();

            return Ok(persons);
        }

    }
}
