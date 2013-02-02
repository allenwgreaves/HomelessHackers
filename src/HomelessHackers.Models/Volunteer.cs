using System;
using MongoDB.Bson;

namespace HomelessHackers.Models
{
    public class Volunteer
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string OrganizationName { get; set; }
        public DateTime? NeededByDate { get; set; }
        public DateTime? NeededUntil { get; set; }
    }
}