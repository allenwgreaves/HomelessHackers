using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HomelessHackers.Data;
using HomelessHackers.Models;
using MongoDB.Bson;

namespace HomelessHackers.Web.Controllers.api
{
    public class DonationsController : ApiController
    {
        // GET api/donations
        public IEnumerable<Donation> Get()
        {
            DataContext db = new DataContext();
            return db.GetDonations();
        }

        // GET api/donations/5
        public IEnumerable<Donation> Get(string id)
        {
            DataContext db = new DataContext();
            return db.GetDonations(id);
        }

        // POST api/Volunteer
        public void Post([FromBody] Donation value)
        {
            DataContext db = new DataContext();

            if (db.GetOrganizations(value.OrganizationName).Any())
            {
                value._id = ObjectId.GenerateNewId().ToString();
                db.AddDonationsToOrganization(value.OrganizationName, value);
            }
        }

        // PUT api/Volunteer/5
        public void Put(int id, [FromBody] Donation value)
        {
        }

        // DELETE api/Volunteer/5
        public void Delete( int id )
        {
        }
    }
}
