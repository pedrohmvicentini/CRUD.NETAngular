namespace WebAPI.Model
{
    public class Contact : ModelBase
    {
        public int PersonId { get; set; }
        public int? Type { get; set; } = (int)TypeContact.None;
        public string? Text { get; set; } = string.Empty;
    }

    public enum TypeContact
    {
        None = 0,
        Phone = 1,
        Whatsapp = 2,
        Email = 3
    }
}
