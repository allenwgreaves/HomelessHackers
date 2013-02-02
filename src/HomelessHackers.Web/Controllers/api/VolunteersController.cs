using HomelessHackers.Models;
using System.Collections.Generic;
using System.Web.Http;
using HomelessHackers.Data;
using MongoDB.Bson;
using System.Linq;

namespace HomelessHackers.Web.Controllers.api
{
    public class VolunteersController : ApiController
    { 
        // GET api/Volunteer
        public IEnumerable<Volunteer> Get()
        {
            DataContext db = new DataContext();
            return db.GetVolunteers();
        }

        // GET api/Volunteer/5
        public IEnumerable<Volunteer> Get(string id)
        {
            DataContext db = new DataContext();
            return db.GetVolunteers(id);
        }

        // POST api/Volunteer
        public void Post([FromBody] Volunteer value)
        {
            DataContext db = new DataContext();

            if (db.GetOrganizations(value.OrganizationName).Any())
            {
                value._id = ObjectId.GenerateNewId().ToString();
                db.AddVolunteersToOrganization(value.OrganizationName, value);
            }
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