using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thisGood10.Models.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersons();
        Task<Person> GetPersonById(int personId);
        Task SavePerson(Person person);
        Task DeletePerson(Person person);

    }
}
