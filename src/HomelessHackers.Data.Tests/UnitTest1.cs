using System;
using System.Linq;
using HomelessHackers.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace HomelessHackers.Data.Tests
{
    [TestClass]
    public class MongoDbTests
    {
        [TestMethod]
        public void Insert()
        {
            const string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient( connectionString );
            var server = client.GetServer();
            var database = server.GetDatabase( "homeless" );
            var organizations = database.GetCollection<Organization>("organizations");
            organizations.Insert( new Organization() { Name = "UGM" } );
        }

        [TestMethod]
        public void InsertChildRecord()
        {
            const string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient( connectionString );
            var server = client.GetServer();
            var database = server.GetDatabase( "homeless" );
            var organizations = database.GetCollection<Organization>("organizations");
            organizations.Remove(new QueryDocument());
            organizations.Insert( new Organization() { Name = "UGM" } );
            organizations.Insert( new Organization() { Name = "Cup-a-cool-water" } );

            var volunteers = database.GetCollection<Volunteer>("volunteers");
            volunteers.Remove(new QueryDocument());
            volunteers.Insert( new Volunteer() { Name = "Hair Dresser", OrganizationName = "UGM" } );
            volunteers.Insert( new Volunteer() { Name = "Hair Dresser", OrganizationName = "Cup-a-cool-water" } );
        }

        [TestMethod]
        public void Read()
        {
            const string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient( connectionString );
            var server = client.GetServer();
            var database = server.GetDatabase( "homeless" );
            var organizations = database.GetCollection<Organization>("organizations");
            var first = organizations.FindOne();
            Console.WriteLine(first.Name);

            var volunteers = database.GetCollection<Volunteer>("volunteers");
            volunteers.Find(new QueryDocument()).ToList()
                .ForEach(x => { Console.WriteLine( x.Name );Console.WriteLine(x.OrganizationName); });
        }

        [TestMethod]
        public void Delete()
        {
            const string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient( connectionString );
            var server = client.GetServer();
            var database = server.GetDatabase( "homeless" );
            var organizations = database.GetCollection<Organization>("organizations");
            organizations.Remove(new QueryDocument());
        }
    }
}
