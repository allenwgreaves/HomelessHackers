using System;
using MongoDB.Bson;

namespace HomelessHackers.Models
{
    public class Volunteer
    {
        public string _id { get; set; }
        public string OrganizationId { get; set; }
        public DateTime? NeededByDate { get; set; }
        public DateTime? NeededUntil { get; set; }
    }
}