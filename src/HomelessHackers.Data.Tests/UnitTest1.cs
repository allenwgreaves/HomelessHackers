using System;
using System.Collections.Generic;
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
            var volunteers = database.GetCollection<Volunteer>("volunteers");
            volunteers.Remove(new QueryDocument());
            var organizations = database.GetCollection<Organization>("organizations");
            organizations.Remove(new QueryDocument());
            organizations.Insert( new Organization()
            {
                    _id = ObjectId.GenerateNewId().ToString(),
                    Name = "UGM",
                    Volunteers =
                            new List<Volunteer>()
                            {
                                    new Volunteer() { _id = ObjectId.GenerateNewId().ToString(), Name = "Hair Dresser", OrganizationName = "UGM" }
                            }
            } );
            organizations.Insert( new Organization()
            {
                    _id = ObjectId.GenerateNewId().ToString(),
                    Name = "Cup-a-cool-water",
                    Volunteers =
                            new List<Volunteer>()
                            {
                                    new Volunteer() { _id = ObjectId.GenerateNewId().ToString(), Name = "Hair Dresser", OrganizationName = "Cup-a-cool-water" }
                            }
            } );
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
