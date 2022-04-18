using HR.Platform.Domain.Entities.Interfaces;
using HR.Platform.Domain.Enums;

namespace HR.Platform.Domain.Entities
{
    public class User : EntityBase, IAuditableEntity, IApprovableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string ExternalProvider { get; set; }
        public UserType? UserType { get; set; }


        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public string DeletedById { get; set; }

        public DateTime? ApprovedAt { get; set; }
        public string ApprovedBy { get; set; }

        public Recruiter Recruiter { get; set; }
    }
}