using System.Collections.Generic;
using System.Web.Http;
using HomelessHackers.Models;

namespace HomelessHackers.Web.Controllers
{
    public class OrganizationsController : ApiController
    {
        // GET api/organizations
        public IEnumerable<Organization> Get()
        {
            return new List<Organization>();
        }

        // GET api/organizations/5
        public Organization Get( int id )
        {
            return new Organization();
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