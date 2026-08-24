
namespace KBM.Domain.Entities
{
    public class Function
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;

        public ICollection<DepartmentFunction> DepartmentFunctions { get; set; } = new List<DepartmentFunction>();
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}