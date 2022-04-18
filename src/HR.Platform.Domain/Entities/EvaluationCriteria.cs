using HR.Platform.Domain.Entities.Interfaces;
using HR.Platform.Domain.Enums;

namespace HR.Platform.Domain.Entities
{
    public class EvaluationCriteria : EntityBase, IAuditableEntity
    {
        public string GroupName { get; set; }
        public string CriteriaName { get; set; }
        public EvaluationLevel? Level { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public string DeletedById { get; set; }
    }
}