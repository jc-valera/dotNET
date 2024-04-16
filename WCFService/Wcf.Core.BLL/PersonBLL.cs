using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcf.Core.Common.Entities;
using Wcf.Core.DAL;

namespace Wcf.Core.BLL
{
    public class PersonBLL
    {
        public PersonDAL PersonDAL;

        public PersonBLL()
        {
            PersonDAL = new PersonDAL();
        }

        public async Task<List<Person>> GetPersons()
        {
            var persons = new List<Person>();

            persons = await PersonDAL.GetPersons();

            return persons;
        }
    }
}
