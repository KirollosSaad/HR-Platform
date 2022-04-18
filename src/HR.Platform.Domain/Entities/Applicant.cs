using HR.Platform.Domain.Entities.Interfaces;

namespace HR.Platform.Domain.Entities
{
    public class Applicant : EntityBase, IAuditableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Summary { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public string DeletedById { get; set; }
    }
}
