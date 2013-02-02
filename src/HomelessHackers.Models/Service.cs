using System;
using MongoDB.Bson;

namespace HomelessHackers.Models
{
    public class Service
    {
        public ObjectId _id { get; set; }
        public ObjectId OrganizationId { get; set; }
        public string Type { get; set; }
        public DateTime? NeededByDate { get; set; }
        public TimeSpan? LengthOfTime { get; set; }
    }
}