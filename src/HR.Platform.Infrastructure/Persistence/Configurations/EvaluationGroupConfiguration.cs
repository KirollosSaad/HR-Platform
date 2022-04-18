using HR.Platform.Application.Constants;
using HR.Platform.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Platform.Infrastructure.Persistence.Configurations
{
    public class EvaluationGroupConfiguration : IEntityTypeConfiguration<EvaluationGroup>
    {
        public void Configure(EntityTypeBuilder<EvaluationGroup> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(FieldLength.SmallLength)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                .HasMaxLength(FieldLength.MediumLength)
                .IsRequired();

            builder.Property(t => t.CreatedById)
                .HasMaxLength(FieldLength.SmallLength)
                .IsRequired(false);

            builder.Property(t => t.UpdatedById)
                .HasMaxLength(FieldLength.SmallLength)
                .IsRequired(false);

            builder.Property(t => t.DeletedById)
                .HasMaxLength(FieldLength.SmallLength)
                .IsRequired(false);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UpdatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.DeletedById)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}