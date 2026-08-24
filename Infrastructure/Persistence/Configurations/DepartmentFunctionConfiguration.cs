using KBM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KBM.Infrastructure.Persistence.Configurations
{
    public class DepartmentFunctionConfiguration : IEntityTypeConfiguration<DepartmentFunction>
    {
        public void Configure(EntityTypeBuilder<DepartmentFunction> builder)
        {
            builder.HasKey(df => new { df.FunctionId, df.DepartmentId });

            builder.HasOne(df => df.Function)
                .WithMany(f => f.DepartmentFunctions)
                .HasForeignKey(df => df.FunctionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(df => df.Department)
                .WithMany(d => d.DepartmentFunctions)
                .HasForeignKey(df => df.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}