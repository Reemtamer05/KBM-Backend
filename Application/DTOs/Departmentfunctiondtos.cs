namespace KBM.Application.DTOs
{
    public class DepartmentFunctionDto
    {
        public Guid FunctionId { get; set; }
        public string FunctionName { get; set; } = null!;
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
    }

    public class CreateDepartmentFunctionDto
    {
        public Guid FunctionId { get; set; }
        public Guid DepartmentId { get; set; }
    }
}