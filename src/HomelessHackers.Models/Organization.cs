using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace HomelessHackers.Models
{
    public class Organization
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
    }
}
