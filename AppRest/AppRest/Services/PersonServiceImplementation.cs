using AppRest.Models;
using AppRest.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AppRest.Services
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(int id)
        {
            //Mock delete
        }
        public List<Person> ListAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Eduardo",
                LastName = "Sabino",
                Gender = "Male",
                Address = "Rua tal"
            };
        }

        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(int id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Eduardo",
                LastName = "Sabino",
                Gender = "Male",
                Address = "Rua tal"
            };
        }


        public Person Update(Person person)
        {
            return person;
        }
    }
}
