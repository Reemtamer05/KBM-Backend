using KBM.Domain.Entities;
using KBM.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KBM.Infrastructure.Persistence
{
   
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Function> Functions => Set<Function>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<DepartmentFunction> DepartmentFunctions => Set<DepartmentFunction>();
        public DbSet<Industry> Industries => Set<Industry>();
        public DbSet<Lesson> Lessons => Set<Lesson>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}