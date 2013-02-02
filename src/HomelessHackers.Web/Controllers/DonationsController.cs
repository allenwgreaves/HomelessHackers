using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomelessHackers.Web.Controllers
{
    public class DonationsController : Controller
    {
        private api.DonationsController apiCntroller = new api.DonationsController();

        //
        // GET: /Donations/

        public ActionResult Index()
        {
            var result = apiCntroller.Get();
            return View(result);
        }

        //
        // GET: /Donations/Details/5

        public ActionResult Details(string name)
        {

            var result = apiCntroller.Get(name).SingleOrDefault();
            return View(result);
        }

        //
        // GET: /Donations/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Donations/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Donations/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Donations/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Donations/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Donations/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
