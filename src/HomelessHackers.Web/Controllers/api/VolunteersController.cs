using HomelessHackers.Models;
using System.Collections.Generic;
using System.Web.Http;
using HomelessHackers.Data;

namespace HomelessHackers.Web.Controllers.api
{
    public class VolunteersController : ApiController
    { 
        // GET api/Volunteer
        public IEnumerable<Volunteer> Get()
        {
            DataContext db = new DataContext();
            return new List<Volunteer>();
        }

        // GET api/Volunteer/5
        public Volunteer Get(int id)
        {
            return new Volunteer();
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