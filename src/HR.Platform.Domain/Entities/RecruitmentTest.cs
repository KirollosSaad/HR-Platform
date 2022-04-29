using HR.Platform.Domain.Entities.Interfaces;

namespace HR.Platform.Domain.Entities
{
    public class RecruitmentTest : EntityBase, IAuditableEntity, IEvaluatableEntity, IPrioritizableEntity
    {
        public string ProcessId { get; set; }
        public string Name { get; set; }
        public int MaxScore { get; set; }
        public double? Score { get; set; }
        public int AcceptanceScore { get; set; }

        public string URL { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        public int Priority { get; set; }
        public string Notes { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public string DeletedById { get; set; }

        public DateTime? EvaluatedAt { get; set; }
        public string EvaluatedById { get; set; }

        public virtual RecruitmentProcess Process { get; set; }
    }
}