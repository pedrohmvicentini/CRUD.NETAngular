namespace WebAPI.Model
{
    public class ModelBase
    {
        public int Id { get; set; } 
        public int? CreatedBy { get; set; } //User Id
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; } //User Id
        public DateTime? UpdatedDate { get; set; }
        public int? DeletedBy { get; set; } //User Id
        public DateTime? DeletedDate { get; set; }
        public bool Active { get; set; }
    }
}
