namespace KBM.Application.DTOs
{
    public class LessonDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string ProjectName { get; set; } = null!;
        public Guid DepartmentId { get; set; }
        public Guid FunctionId { get; set; }
        public Guid IndustryId { get; set; }
        public string ValueProposition { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string TargetAudience { get; set; } = null!;
        public string Engage1 { get; set; } = null!;
        public string PersonaFocalPoint { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class CreateLessonDto
    {
        public string Title { get; set; } = null!;
        public string ProjectName { get; set; } = null!;
        public Guid DepartmentId { get; set; }
        public Guid FunctionId { get; set; }
        public Guid IndustryId { get; set; }
        public string ValueProposition { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string TargetAudience { get; set; } = null!;
        public string Engage1 { get; set; } = null!;
        public string PersonaFocalPoint { get; set; } = null!;
    }

    public class UpdateLessonDto
    {
        public string Title { get; set; } = null!;
        public string ProjectName { get; set; } = null!;
        public Guid DepartmentId { get; set; }
        public Guid FunctionId { get; set; }
        public Guid IndustryId { get; set; }
        public string ValueProposition { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string TargetAudience { get; set; } = null!;
        public string Engage1 { get; set; } = null!;
        public string PersonaFocalPoint { get; set; } = null!;
    }
}