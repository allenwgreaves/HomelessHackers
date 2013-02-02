using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomelessHackers.Web.Controllers
{
    public class DonationsController : Controller
    {
        private api.DonationsController ApiController = new api.DonationsController();

        //
        // GET: /Donations/

        public ActionResult Index()
        {
            var result = ApiController.Get();
            return View(result);
        }

        //
        // GET: /Donations/Details/5

        public ActionResult Details(string _id)
        {

            var result = ApiController.Get( _id );
            return View(result);
        }

        [HttpPost]
        public ActionResult Search( string search )
        {
            var results = ApiController.Search( search );
            return View("Index", results );
        }
    }
}
