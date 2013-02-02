using System;

namespace HomelessHackers.Models
{
    public class Services
    {
        public int ServiceId { get; set; }
        public int OrganizationId { get; set; }
        public string Type { get; set; }
        public DateTime? RequiredDate { get; set; }
        public TimeSpan? LengthOfTime { get; set; }
    }
}