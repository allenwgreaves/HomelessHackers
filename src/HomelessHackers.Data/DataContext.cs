using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomelessHackers.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

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

        public virtual IEnumerable<Organization> GetOrganizations(string name = null)
        {
            var query = string.IsNullOrEmpty( name ) ? new QueryDocument() : Query<Organization>.EQ( x => x.Name, name );
            return GetCollection<Organization>().Find(query).ToList();
        }

        public virtual IEnumerable<Volunteer> GetVolunteers(string name = null)
        {
            var query = string.IsNullOrEmpty( name ) ? new QueryDocument() : Query<Volunteer>.EQ( x => x.Name, name );
            return GetCollection<Volunteer>().Find( new QueryDocument() ).ToList();
        }

        public virtual IEnumerable<Donation> GetDonations(string name = null)
        {
            var query = string.IsNullOrEmpty( name ) ? new QueryDocument() : Query<Donation>.EQ( x => x.Name, name );
            return GetCollection<Donation>().Find( new QueryDocument() ).ToList();
        }

        public virtual IEnumerable<Volunteer> GetVolunteersForOrganization( string organizationName )
        {
            if ( organizationName == null )
            {
                throw new ArgumentNullException( "organizationName" );
            }
            return GetCollection<Volunteer>()
                .Find( Query<Volunteer>.EQ( x => x.OrganizationName, organizationName) ).ToList();
        }

        public virtual IEnumerable<Donation> GetDonationsForOrganization( string organizationName )
        {
            if ( organizationName == null )
            {
                throw new ArgumentNullException( "organizationName" );
            }
            return GetCollection<Donation>()
                .Find( Query<Donation>.EQ( x => x.OrganizationName, organizationName) ).ToList();
        }
    }
}
