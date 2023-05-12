using System;
using System.Collections.Generic;

namespace ATS.EFCore.DBFirst.API.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? EmailId { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
