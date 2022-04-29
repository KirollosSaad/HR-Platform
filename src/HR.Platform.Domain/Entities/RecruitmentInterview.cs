using HR.Platform.Domain.Entities.Interfaces;

namespace HR.Platform.Domain.Entities
{
    public class RecruitmentInterview : EntityBase, IAuditableEntity, IPrioritizableEntity
    {
        public string ProcessId { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public List<EvaluationCriteria> Evaluation { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public string DeletedById { get; set; }

        public virtual RecruitmentProcess Process { get; set; }
    }
}