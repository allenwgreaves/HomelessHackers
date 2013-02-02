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
        protected virtual string ConnectionString
        {
            get
            {
                return "mongodb://localhost";
            }
        }

        protected virtual MongoDatabase GetDatabase()
        {
            const string connectionString = "mongodb://localhost";
            var client = new MongoClient( connectionString );
            var server = client.GetServer();
            return server.GetDatabase( "homeless" );
        }

        private MongoCollection<TDataType> GetCollection<TDataType>()
        {
            var database = GetDatabase();
            return database.GetCollection<TDataType>(typeof(TDataType).Name.ToLower() + "s");
        }

        public virtual IEnumerable<Organization> GetOrganizations(string id = null)
        {
            return GetCollection<Organization>().Find(new QueryDocument()).ToList();
        }

        public virtual IEnumerable<Volunteer> GetVolunteers()
        {
            return GetCollection<Volunteer>().Find( new QueryDocument() ).ToList();
        }

        public virtual IEnumerable<Donation> GetDonations()
        {
            return GetCollection<Donation>().Find( new QueryDocument() ).ToList();
        }
    }
}
