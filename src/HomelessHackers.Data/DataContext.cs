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
            var query = string.IsNullOrEmpty( name ) ? new QueryDocument() : Query.EQ( "Volunteers.Name", name );
            return GetCollection<Organization>().Find( new QueryDocument() )
                .SelectMany( x => x.Volunteers ).Where(x => x.Name == name  ).ToList();
        }

        public virtual IEnumerable<Donation> GetDonations(string name = null)
        {
            var query = string.IsNullOrEmpty( name ) ? new QueryDocument() : Query.EQ( "Donations.Name", name );
            return GetCollection<Organization>().Find( new QueryDocument() )
                .SelectMany( x => x.Donations ).Where(x => x.Name == name  ).ToList();
        }

        public virtual IEnumerable<Volunteer> GetVolunteersForOrganization( string organizationName )
        {
            if ( organizationName == null )
            {
                throw new ArgumentNullException( "organizationName" );
            }
            return GetCollection<Organization>()
                .Find( Query<Organization>.EQ( x => x.Name, organizationName) ).SelectMany( x => x.Volunteers ).ToList();
        }

        public virtual IEnumerable<Donation> GetDonationsForOrganization( string organizationName )
        {
            if ( organizationName == null )
            {
                throw new ArgumentNullException( "organizationName" );
            }
            return GetCollection<Organization>()
                .Find( Query<Organization>.EQ( x => x.Name, organizationName) ).SelectMany( x => x.Donations ).ToList();
        }

        public virtual void AddDonationsToOrganization( string organizationName, Donation newDonation)
        {
            //var collection = GetCollection<Organization>().Find( Query<Organization>.EQ( x => x.Name, organizationName) ).SelectMany(x => x.Donations).ToList();
            var collection = GetCollection<Organization>();
            var query = Query.EQ("Name", organizationName);
            
            var update = Update.AddToSet("Donations", newDonation.ToBson<Donation>());
            collection.Update(query, update); //cant deserialize stuffs

        }
    }
}
