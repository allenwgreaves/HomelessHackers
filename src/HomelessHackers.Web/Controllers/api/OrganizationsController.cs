using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HomelessHackers.Models;
using HomelessHackers.Data;

namespace HomelessHackers.Web.Controllers
{
    public class OrganizationsController : ApiController
    {
        // GET api/organizations
        public IEnumerable<Organization> Get()
        {
            DataContext db = new DataContext();
            return db.GetOrganizations();
        }

        // GET api/organizations/5
        public Organization Get( string id )
        {
            DataContext db = new DataContext();
            return db.GetOrganizations( id ).First();
        }

        // POST api/organizations
        public void Post( [FromBody] Organization value )
        {
        }

        // PUT api/organizations/5
        public void Put( int id, [FromBody] Organization value )
        {
        }

        // DELETE api/organizations/5
        public void Delete( int id )
        {
        }
    }
}