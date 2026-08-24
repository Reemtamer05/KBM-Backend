using KBM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KBM.Infrastructure.Persistence.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Title).IsRequired().HasMaxLength(250);
            builder.Property(l => l.ProjectName).IsRequired().HasMaxLength(250);
            builder.Property(l => l.ValueProposition).HasMaxLength(500);
            builder.Property(l => l.Category).HasMaxLength(100);
            builder.Property(l => l.TargetAudience).HasMaxLength(250);
            builder.Property(l => l.PersonaFocalPoint).HasMaxLength(250);

            builder.HasOne(l => l.Function)
                .WithMany(f => f.Lessons)
                .HasForeignKey(l => l.FunctionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Department)
                .WithMany(d => d.Lessons)
                .HasForeignKey(l => l.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.Industry)
                .WithMany(i => i.Lessons)
                .HasForeignKey(l => l.IndustryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}