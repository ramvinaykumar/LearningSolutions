﻿namespace WebApi.AuditTrial.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string UserEmail => "John.Doe@gmail.com";
        public required string EntityName { get; set; }
        public required string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public required string Changes { get; set; }
    }
}
