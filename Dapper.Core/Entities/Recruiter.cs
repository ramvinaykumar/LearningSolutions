using System;

namespace Dapper.Core.Entities
{
    public class Recruiter
    {
       
        public int UserID { get; set; }

      
        public string UserName { get; set; }

      
        public string Password { get; set; }

      
        public string Email { get; set; }

      
        public string Mobile { get; set; }

        public string Location { get; set; }

    
        public bool IsActive { get; set; }

    
        public DateTime CreatedDate { get; set; }

    }
}
