using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Interfaces;

namespace WebAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly DataContext _context;

        public PersonService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetAll()
        {
            return await _context.Person.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Person.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<List<Person>> CreatePerson(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();

            return await _context.Person.ToListAsync();
        }

        public async Task<List<Person>> UpdatePerson(Person person)
        {
            var dbPerson = await _context.Person.FindAsync(person.Id);
            if (dbPerson == null)
                throw new Exception("Contact not found.");

            dbPerson.FirstName = person.FirstName?.Trim();
            dbPerson.LastName = person.LastName?.Trim();

            await _context.SaveChangesAsync();

            return await _context.Person.ToListAsync();
        }

        public async Task<List<Person>> DeletePerson(int id)
        {
            var dbPerson = await _context.Person.FindAsync(id);
            if (dbPerson == null)
                throw new Exception("Contact not found.");

            _context.Person.Remove(dbPerson);
            await _context.SaveChangesAsync();

            return await _context.Person.ToListAsync();
        }
    }
}
