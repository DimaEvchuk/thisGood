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
        public void DeletePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            throw new NotImplementedException();
        }

        public Person GetPersonById(int personId)
        {
            throw new NotImplementedException();
        }

        public void SavePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
