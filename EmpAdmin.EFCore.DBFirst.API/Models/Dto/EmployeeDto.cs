namespace EmpAdmin.EFCore.DBFirst.API.Models.Dto
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }

        public  string? Name { get; set; }

        public  string? Email { get; set; }

        public  string? Address { get; set; }

        public  string? Designation { get; set; }

        public string? Phone { get; set; }

        public decimal Salary { get; set; }
    }
}
