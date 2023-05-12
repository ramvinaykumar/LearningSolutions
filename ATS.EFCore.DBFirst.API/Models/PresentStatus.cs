using System;
using System.Collections.Generic;

namespace ATS.EFCore.DBFirst.API.Models
{
    public partial class PresentStatus
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        /// <summary>
        /// F - Full Day, H - Half Day, A - Absent
        /// </summary>
        public string? PresentType { get; set; }
        public int EmpId { get; set; }
    }
}
