using System.Collections.Generic;
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
            //return new List<Organization>();
            /*var list = new List<Organization>();
            
            list.AddRange(new[]{
                new Organization { Name = "Kelly's mom", _id = System.Guid.NewGuid().ToString() },
                new Organization { Name = "Kenny's mom", _id = System.Guid.NewGuid().ToString() },
                new Organization { Name = "Adam's mom", _id = System.Guid.NewGuid().ToString() },
                new Organization { Name = "Allen's mom", _id = System.Guid.NewGuid().ToString() }
            });
            return list;*/
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