namespace KBM.Domain.Entities
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string ProjectName { get; set; } = null!;

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        public Guid FunctionId { get; set; }
        public Function Function { get; set; } = null!;

        public Guid IndustryId { get; set; }
        public Industry Industry { get; set; } = null!;

        public string ValueProposition { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string TargetAudience { get; set; } = null!;
        public string Engage1 { get; set; } = null!;
        public string PersonaFocalPoint { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
}