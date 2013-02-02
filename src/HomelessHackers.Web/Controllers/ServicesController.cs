using System.Collections.Generic;
using System.Web.Http;
using System.Web.Services.Description;

namespace HomelessHackers.Web.Controllers
{
    public class ServicesController : ApiController
    {
        // GET api/services
        public IEnumerable<Service> Get()
        {
            return List<Service>();
        }

        // GET api/services/5
        public Service Get( int id )
        {
            return new Service();
        }

        // POST api/services
        public void Post( [FromBody] Service value )
        {
        }

        // PUT api/services/5
        public void Put( int id, [FromBody] Service value )
        {
        }

        // DELETE api/services/5
        public void Delete( int id )
        {
        }
    }
}