using System;
using System.Linq;
using HomelessHackers.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;

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
        public void Read()
        {
            const string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient( connectionString );
            var server = client.GetServer();
            var database = server.GetDatabase( "homeless" );
            var organizations = database.GetCollection<Organization>("organizations");
            var first = organizations.FindOne();
            Console.WriteLine(first._id);
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
