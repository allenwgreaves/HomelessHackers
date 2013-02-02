using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace HomelessHackers.Models
{
    public class Organization
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public List<Volunteer> Volunteers { get; set; }
        public List<Donation> Donations { get; set; }
    }
}
