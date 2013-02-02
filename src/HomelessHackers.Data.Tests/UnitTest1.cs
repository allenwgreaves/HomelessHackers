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
                                    new Volunteer() { _id = ObjectId.GenerateNewId().ToString(), Name = "Hair Dresser", OrganizationName = "UGM" },
                                    new Volunteer() { _id = ObjectId.GenerateNewId().ToString(), Name = "Food Taster", OrganizationName = "UGM" },
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
            var first =
                    organizations.Find( Query.EQ( "Volunteers.Name", "Hair Dresser" ) )
                                 .FirstOrDefault();
            Console.WriteLine(first.Name);
            first.Volunteers.Where(x => x.Name == "Hair Dresser" ).ToList().ForEach( x => Console.WriteLine(x.Name) );
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

        [TestMethod]
        public void InsertTestData()
        {
            const string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("homeless");
            var organizations = database.GetCollection<Organization>("organizations");
            organizations.Insert(new Organization()
            {
                _id = ObjectId.GenerateNewId().ToString(),
                Name = "UGM",
                Address1 = "1234 NiceData Dr.",
                ZipCode = "12345",
                City = "Happy City",
                State = "Not-Insanity",
                PhoneNumber = "(123)456-7891",
                Volunteers = new List<Volunteer>()
                            {
                                    new Volunteer() { _id = ObjectId.GenerateNewId().ToString(), Name = "Hair Dresser", OrganizationName = "UGM", NeededByDate = new DateTime(2013, 02, 03, 06, 00, 00),
                                    NeededUntil = new DateTime(2013, 02, 03, 07, 30, 00) 
                                    },
                                    new Volunteer() { _id = ObjectId.GenerateNewId().ToString(), Name = "Mechanic", OrganizationName = "UGM", NeededByDate = new DateTime(2013, 02, 03, 06, 00, 00),
                                    NeededUntil = new DateTime(2013, 02, 03, 07, 30, 00) 
                                    }
                            },
                Donations = new List<Donation>(){
                            new Donation() { _id = ObjectId.GenerateNewId().ToString(), Name = "Canned Beans", OrganizationName = "UGM", Quantity = 500, NeededByDate = new DateTime(2013, 02, 03, 06, 00, 00)},
                            new Donation() { _id = ObjectId.GenerateNewId().ToString(), Name = "Rice", OrganizationName = "UGM", Quantity = 5, NeededByDate = new DateTime(2013, 02, 03, 06, 00, 00)}
                }
            });


            organizations.Insert(new Organization()
            {
                _id = ObjectId.GenerateNewId().ToString(),
                Name = "Cup-a-cool-water",
                Address1 = "1234 bleck Dr.",
                ZipCode = "12345",
                City = "HardKnock",
                State = "Hell",
                PhoneNumber = "(123)456-7891",
                Volunteers = new List<Volunteer>()
                            {
                                    new Volunteer() { _id = ObjectId.GenerateNewId().ToString(), Name = "Hair Dresser", OrganizationName = "Cup-a-cool-water", NeededByDate = new DateTime(2013, 02, 03, 06, 00, 00),
                                    NeededUntil = new DateTime(2013, 02, 03, 07, 30, 00) 
                                    },
                                    new Volunteer() { _id = ObjectId.GenerateNewId().ToString(), Name = "Mechanic", OrganizationName = "Cup-a-cool-water", NeededByDate = new DateTime(2013, 02, 03, 06, 00, 00),
                                    NeededUntil = new DateTime(2013, 02, 03, 07, 30, 00) 
                                    }
                            },
                Donations = new List<Donation>(){
                            new Donation() { _id = ObjectId.GenerateNewId().ToString(), Name = "Canned Beans", OrganizationName = "Cup-a-cool-water", Quantity = 500, NeededByDate = new DateTime(2013, 02, 03, 06, 00, 00)},
                            new Donation() { _id = ObjectId.GenerateNewId().ToString(), Name = "Rice", OrganizationName = "Cup-a-cool-water", Quantity = 5, NeededByDate = new DateTime(2013, 02, 03, 06, 00, 00)}
                }
            });
        }
    }
}
