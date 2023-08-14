using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Interfaces;
using WebAPI.Model;

namespace WebAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly DataContext _context;
        public ContactService(DataContext context)
        {
            _context = context;
        }

        public Task<List<Contact>> GetAllByPersonId(int personId)
        {
            throw new NotImplementedException();
        }
    }
}
