namespace KBM.Application.DTOs
{
    public class FunctionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }

    public class CreateFunctionDto
    {
        public string Name { get; set; } = null!;
    }

    public class UpdateFunctionDto
    {
        public string Name { get; set; } = null!;
    }
}