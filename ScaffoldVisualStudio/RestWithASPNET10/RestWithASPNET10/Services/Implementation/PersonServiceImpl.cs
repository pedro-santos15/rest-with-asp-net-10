using RestWithASPNET10.Exceptions;
using RestWithASPNET10.Model;
using RestWithASPNET10.Model.Context;

namespace RestWithASPNET10.Services.Implementation
{
    public class PersonServiceImpl : IPersonService
    {

        private MSSQLContext _context;

        public PersonServiceImpl(MSSQLContext context)
        {
            _context = context;
        }
        public Person FindById(long id)
        {
            var person = _context.People.Find(id);
            
            if (person == null) 
            {
                throw new PersonNotFoundException("Person not found");
            }

            return person;
        }
        public List<Person> FindAll()
        {
            return _context.People.ToList();
        }

        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }

        public Person Update(Person person)
        {
            var findPerson = _context.People.Find(person.Id);

            if (findPerson != null)
            {
                _context.Entry(findPerson).CurrentValues.SetValues(person);
                _context.SaveChanges();
                return person;
            }
            else
            {
                throw new PersonNotFoundException("Person not found");
            }
           
        }
        public void Delete(long id)
        {
            var findPerson = _context.People.Find(id);

            if (findPerson != null) 
            {
                _context.People.Remove(findPerson);
                _context.SaveChanges();
            } else { throw new PersonNotFoundException("Person not found");}
            }
    }
}
