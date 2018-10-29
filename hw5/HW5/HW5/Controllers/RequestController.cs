using HW5.DAL;
using HW5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW5.Controllers
{
    public class RequestController : Controller

        {
            private RequestsContext db = new RequestsContext();

            // GET: Requests
            public ActionResult Index()
            {
                return View(db.Requests.ToList());
            }


            // GET: Requests
            public ActionResult Requests()
            {
                return View();
            }

            // POST Requests
            [HttpPost]
            public ActionResult Requests(Requests requests)
            {
                if (ModelState.IsValid)
                {
                //Add new request to the database
                    db.Requests.Add(requests);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                //Return the 
                return View(requests);
            }
        }
    }
