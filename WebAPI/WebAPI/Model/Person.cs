namespace WebAPI.Model
{
    public class Person : ModelBase
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
