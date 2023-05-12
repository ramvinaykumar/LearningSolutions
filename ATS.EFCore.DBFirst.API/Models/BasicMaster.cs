using System;
using System.Collections.Generic;

namespace ATS.EFCore.DBFirst.API.Models
{
    public partial class BasicMaster
    {
        public int Id { get; set; }
        public string DataValue { get; set; } = null!;
        public string DataText { get; set; } = null!;
        public string DataFor { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
