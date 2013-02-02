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
    internal class VolunteerView
    {
        public string _id { get; set; }
        public Volunteer value { get; set; }
    }

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
            var result = GetCollection<Organization>().Find( new QueryDocument() )
                .SelectMany( x => x.Volunteers );
            return string.IsNullOrEmpty( name ) ? result.ToList() : result.Where(x => x.Name == name  ).ToList();
        }

        public virtual IEnumerable<Volunteer> SearchVolunteers( string criteria )
        {
            var mapFunction =
                    @"function() {
                            this.Volunteers.forEach(function (value) {
                            var criteria = '" + criteria + @"';
                            if(value.Name.match(criteria)) {
                                emit(value._id, value);
                            }
                        });
                    }";
            var reduceFunction =
                    @"function(id, volunteer) {
                            return volunteer;
                    }";
            var results = GetCollection<Organization>()
                    .MapReduce( new BsonJavaScript( mapFunction ), new BsonJavaScript( reduceFunction ) )
                    .GetResultsAs<VolunteerView>()
                    .Select( x => x.value )
                    .ToList();
            return results;
        }

        public virtual IEnumerable<Donation> GetDonations(string name = null)
        {
            var query = string.IsNullOrEmpty( name ) ? new QueryDocument() : Query.EQ( "Donations.Name", name );
            var result = GetCollection<Organization>().Find( new QueryDocument() )
                .SelectMany( x => x.Donations );
            return string.IsNullOrEmpty( name ) ? result.ToList() : result.Where(x => x.Name == name  ).ToList();
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
            var collection = GetCollection<Organization>();
            collection.Update( Query<Organization>.EQ( x => x.Name, organizationName ),
                               Update<Organization>.Push( x => x.Donations, newDonation ) );

        }

        public virtual void AddVolunteersToOrganization(string organizationName, Volunteer newVolunteer)
        {
            var collection = GetCollection<Organization>();
            collection.Update(Query<Organization>.EQ(x => x.Name, organizationName),
                               Update<Organization>.Push(x => x.Volunteers, newVolunteer));

        }
    }
}
