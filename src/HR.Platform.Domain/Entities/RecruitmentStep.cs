using HR.Platform.Domain.Entities.Interfaces;
using HR.Platform.Domain.Enums;

namespace HR.Platform.Domain.Entities
{
    public class RecruitmentStep : EntityBase , IAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public EvaluationLevel? Status { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public string DeletedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
        public virtual User DeletedBy { get; set; }
    }
}
