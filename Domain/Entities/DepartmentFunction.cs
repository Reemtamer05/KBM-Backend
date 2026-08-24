namespace KBM.Domain.Entities
{
    public class DepartmentFunction
    {
        public Guid FunctionId { get; set; }
        public Function Function { get; set; } = null!;

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
    }
}