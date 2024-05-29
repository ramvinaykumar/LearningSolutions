namespace EmpAdmin.EFCore.DBFirst.API.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Address { get; set; }

        public required string Designation { get; set; }

        public string? Phone { get; set; }

        public decimal Salary { get; set; }
    }
}
