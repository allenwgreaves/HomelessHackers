using System.Collections.Generic;
using System.Web.Mvc;
using HomelessHackers.Models;

namespace HomelessHackers.Web.Controllers
{
    public class OrganizationsController : Controller
    {
        //
        // GET: /Organizations/
        private readonly api.OrganizationsController apiController = new api.OrganizationsController();


        public ActionResult Index()
        {
            IEnumerable<Organization> results = apiController.Get();

            return View( results );
        }

        //
        // GET: /Organizations/Details/5

        public ActionResult Details( string name )
        {
            Organization results = apiController.Get(name);

            return View( results );
        }
    }
}