using System;
using MongoDB.Bson;

namespace HomelessHackers.Models
{
    public class Donation
    {
        public ObjectId _id { get; set; }
        public ObjectId OrganizationId { get; set; }
        public string Type { get; set; }
        public DateTime? NeededByDate { get; set; }
    }
}