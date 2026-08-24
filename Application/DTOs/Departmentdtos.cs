namespace KBM.Application.DTOs
{
    public class DepartmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class CreateDepartmentDto
    {
        public string Name { get; set; } = null!;
    }

    public class UpdateDepartmentDto
    {
        public string Name { get; set; } = null!;
    }
}