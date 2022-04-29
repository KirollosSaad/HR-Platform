using HR.Platform.Domain.Entities.Interfaces;

namespace HR.Platform.Domain.Entities
{
    public class RecruitmentProcess : EntityBase, IAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<RecruitmentTest> Tests { get; set; }
        public virtual ICollection<RecruitmentInterview> Interviews { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public string DeletedById { get; set; }

        public RecruitmentProcess()
        {
            Tests = new HashSet<RecruitmentTest>();
            Interviews = new HashSet<RecruitmentInterview>();
        }
    }
}