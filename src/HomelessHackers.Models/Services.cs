using System;
using MongoDB.Bson;

namespace HomelessHackers.Models
{
    public class Services
    {
        public ObjectId _id { get; set; }
        public ObjectId OrganizationId { get; set; }
        public string Type { get; set; }
        public DateTime? RequiredDate { get; set; }
        public TimeSpan? LengthOfTime { get; set; }
    }
}