namespace WebAPI.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> GetAll();

        Task<Person> GetByIdAsync(int id);
        Task<List<Person>> CreatePerson(Person person);
        Task<List<Person>> UpdatePerson(Person person);
        Task<List<Person>> DeletePerson(int id);
    }
}
