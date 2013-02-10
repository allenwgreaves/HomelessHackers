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

    internal class DonationView
    {
        public string _id { get; set; }
        public Donation value { get; set; }
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

        public virtual Volunteer GetVolunteerById( string id )
        {
            var mapFunction = GetChildByIdMapFunction( "Volunteer", id );
            var reduceFunction = GetChildByIdMapFunction();
            var result = GetCollection<Organization>()
                    .MapReduce( new BsonJavaScript( mapFunction ), new BsonJavaScript( reduceFunction ) )
                    .GetResultsAs<VolunteerView>()
                    .Select( x => x.value )
                    .SingleOrDefault();
            return result;
        }

        public virtual IEnumerable<Volunteer> SearchVolunteers( string criteria )
        {
            var mapFunction = GetSimpleSearchMapFunction( "Volunteer", criteria );
            var reduceFunction = GetSimpleSearchReduceFunction();
            var results = GetCollection<Organization>()
                    .MapReduce( new BsonJavaScript( mapFunction ), new BsonJavaScript( reduceFunction ) )
                    .GetResultsAs<VolunteerView>()
                    .Select( x => x.value )
                    .ToList();
            return results;
        }

        public virtual Donation GetDonationById( string id )
        {
            var mapFunction = GetChildByIdMapFunction( "Donation", id );
            var reduceFunction = GetChildByIdMapFunction();
            var result = GetCollection<Organization>()
                    .MapReduce( new BsonJavaScript( mapFunction ), new BsonJavaScript( reduceFunction ) )
                    .GetResultsAs<DonationView>()
                    .Select( x => x.value )
                    .SingleOrDefault();
            return result;
        }

        public virtual IEnumerable<Donation> SearchDonations( string criteria )
        {
            var mapFunction = GetSimpleSearchMapFunction( "Donation", criteria );
            var reduceFunction = GetSimpleSearchReduceFunction();
            var results = GetCollection<Organization>()
                    .MapReduce( new BsonJavaScript( mapFunction ), new BsonJavaScript( reduceFunction ) )
                    .GetResultsAs<DonationView>()
                    .Select( x => x.value )
                    .ToList();
            return results;
        }

        private static string GetChildByIdMapFunction(string child, string id )
        {
            var mapFunction =
                    @"function() {
                            this." + child + @"s.forEach(function (value) {
                            var criteria = '" + id + @"';
                            if(value._id === criteria) {
                                emit(value._id, value);
                            }
                        });
                    }";
            return mapFunction;
        }

        private static string GetChildByIdMapFunction()
        {
            var reduceFunction =
                    @"function(id, child) {
                            return child;
                    }";
            return reduceFunction;
        }

        private static string GetSimpleSearchMapFunction(string child, string criteria )
        {
            var mapFunction =
                    @"function() {
                            this." + child + @"s.forEach(function (value) {
                            var criteria = '" + criteria + @"';
                            if(value.Name.match(criteria)) {
                                emit(value._id, value);
                            }
                        });
                    }";
            return mapFunction;
        }

        private static string GetSimpleSearchReduceFunction()
        {
            var reduceFunction =
                    @"function(id, volunteer) {
                            return volunteer;
                    }";
            return reduceFunction;
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

        public virtual void RemoveVolunteerFromOrganization(string organizationName, Volunteer oldVolunteer)
        {
            var collection = GetCollection<Organization>();
            collection.Update(Query<Organization>.EQ(x => x.Name, organizationName),
                               Update<Organization>.Pull(x => x.Volunteers, oldVolunteer));

        }

        public virtual void RemoveDonationFromOrganization(string organizationName, Donation oldDonation)
        {
            var collection = GetCollection<Organization>();
            collection.Update(Query<Organization>.EQ(x => x.Name, organizationName),
                               Update<Organization>.Pull(x => x.Donations, oldDonation));

        }

        public virtual void RemoveVolunteersOfNameFromOrganization(string organizationName, string oldVolunteer)
        {
            var collection = GetCollection<Organization>();
            IEnumerable<Volunteer> curVolunteers = GetVolunteersForOrganization(organizationName);
            curVolunteers = (from c in curVolunteers
                             where c.Name.Equals(oldVolunteer)
                             select c);
            collection.Update(Query<Organization>.EQ(x => x.Name, organizationName),
                               Update<Organization>.PullAll(x => x.Volunteers, curVolunteers));

        }

        public virtual void RemoveDonationsOfNameFromOrganization(string organizationName, string oldDonation)
        {
            var collection = GetCollection<Organization>();
            IEnumerable<Donation> curDonations = GetDonationsForOrganization(organizationName);
            curDonations = (from c in curDonations
                             where c.Name.Equals(oldDonation)
                             select c);
            collection.Update(Query<Organization>.EQ(x => x.Name, organizationName),
                               Update<Organization>.PullAll(x => x.Donations, curDonations));

        }
    }
}
