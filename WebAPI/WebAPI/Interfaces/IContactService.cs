using WebAPI.Model;

namespace WebAPI.Interfaces
{
    public interface IContactService
    {
        public Task<List<Contact>> GetAllByPersonId(int personId);

    }
}
