using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thisGood10.Models.Repositories.Interfaces;


namespace thisGood10.Models.Repositories.EntityFrameworks
{
    public class EFPersonRepository : IPersonRepository
    {
        public Task DeletePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GetAllPersons()
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetPersonById(int personId)
        {
            throw new NotImplementedException();
        }

        public Task SavePerson(Person person)
        {
            throw new NotImplementedException();
        }

       
    }
}
