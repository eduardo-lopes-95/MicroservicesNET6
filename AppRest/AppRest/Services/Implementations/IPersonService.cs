using AppRest.Models;
using System.Collections.Generic;

namespace AppRest.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindById(int id);
        List<Person> ListAll();
        Person Update(Person person);
        void Delete(int id);
    }
}
