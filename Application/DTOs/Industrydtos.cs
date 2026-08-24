namespace KBM.Application.DTOs
{
    public class IndustryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class CreateIndustryDto
    {
        public string Name { get; set; } = null!;
    }

    public class UpdateIndustryDto
    {
        public string Name { get; set; } = null!;
    }
}