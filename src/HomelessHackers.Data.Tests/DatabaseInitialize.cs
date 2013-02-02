using System;
using System.Collections.Generic;
using HomelessHackers.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HomelessHackers.Data.Tests
{
    public class DatabaseInitialize
    {
        public static void Execute()
        {
            const string connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("homeless");
            var organizations = database.GetCollection<Organization>("organizations");
            organizations.Remove(new QueryDocument());
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
                                    new Volunteer() { _id = ObjectId.GenerateNewId().ToString(), Name = "Volunteer", OrganizationName = "Cup-a-cool-water", NeededByDate = new DateTime(2013, 02, 03, 06, 00, 00),
                                    NeededUntil = new DateTime(2013, 02, 03, 07, 30, 00) 
                                    },
                                    new Volunteer() { _id = ObjectId.GenerateNewId().ToString(), Name = "Mechanic", OrganizationName = "Cup-a-cool-water", NeededByDate = new DateTime(2013, 02, 03, 06, 00, 00),
                                    NeededUntil = new DateTime(2013, 02, 03, 07, 30, 00) 
                                    }
                            },
                Donations = new List<Donation>(){
                            new Donation() { _id = ObjectId.GenerateNewId().ToString(), Name = "Non-perishable Food", OrganizationName = "Cup-a-cool-water", Quantity = 500, NeededByDate = new DateTime(2013, 02, 03, 06, 00, 00)},
                            new Donation() { _id = ObjectId.GenerateNewId().ToString(), Name = "Rice", OrganizationName = "Cup-a-cool-water", Quantity = 5, NeededByDate = new DateTime(2013, 02, 03, 06, 00, 00)}
                }
            });
        }
    }
}
