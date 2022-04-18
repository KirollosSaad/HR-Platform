namespace HR.Platform.Domain.Entities.Interfaces
{
    public interface IApprovableEntity
    {
        public DateTime? ApprovedAt { get; set; }
        public string ApprovedBy { get; set; }
    }
}
