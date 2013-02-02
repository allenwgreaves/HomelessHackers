using System;
using MongoDB.Bson;

namespace HomelessHackers.Models
{
    public class Donation
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string OrganizationName { get; set; }
        public int Quantity { get; set; }
        public DateTime? NeededByDate { get; set; }
    }
}