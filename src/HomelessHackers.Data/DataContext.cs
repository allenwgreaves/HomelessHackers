using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomelessHackers.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HomelessHackers.Data
{
    public class DataContext
    {
        public virtual IEnumerable<Organization> GetOrganizations()
        {
            const string connectionString = "mongodb://localhost";
            var client = new MongoClient( connectionString );
            var server = client.GetServer();
            var database = server.GetDatabase( "homeless" );
            var organization = database.GetCollection<Organization>("organizations");
            return organization.Find(new QueryDocument()).ToList();
        }

        public virtual IEnumerable<Services> GetServices()
        {
            return Enumerable.Empty<Services>();
        }
    }
}
