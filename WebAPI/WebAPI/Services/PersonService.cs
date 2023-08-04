using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetPeople();
        Task<List<Person>> CreatePerson(Person person);
        Task<List<Person>> UpdatePerson(Person person);
        Task<List<Person>> DeletePerson(int id);
    }
    public class PersonService : IPersonService
    {
        private readonly DataContext _context;

        public PersonService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetPeople()
        {
            return await _context.Person.ToListAsync();
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
