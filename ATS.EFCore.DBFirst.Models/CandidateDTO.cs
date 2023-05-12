using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.EFCore.DBFirst.Models
{
    public class CandidateDTO
    {
        public int CandidateID { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? Mobile { get; set; }

        public string? Email { get; set; }

        public string? Gender { get; set; }

        public string? Address { get; set; }

        public string? PrimarySkill { get; set; }

        public string? TechSkills { get; set; }

        public string? Domain { get; set; }

        public string? CTC { get; set; }

        public string? ECTC { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
