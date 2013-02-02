using System.Collections.Generic;
using System.Web.Http;

namespace HomelessHackers.Web.Controllers.api
{
    public class ListingsController : ApiController
    {
        // GET api/listings
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/listings/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/listings
        public void Post([FromBody]string value)
        {
        }

        // PUT api/listings/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/listings/5
        public void Delete(int id)
        {
        }
    }
}
