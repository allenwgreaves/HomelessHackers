using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HomelessHackers.Data;
using HomelessHackers.Models;

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
        public void Post([FromBody] Volunteer value)
        {
        }

        // PUT api/Volunteer/5
        public void Put(int id, [FromBody] Volunteer value)
        {
        }

        // DELETE api/Volunteer/5
        public void Delete( int id )
        {
        }
    }
}
