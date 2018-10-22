using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace homework4.Controllers
{
    public class ConverterController : Controller
    {
        // GET: Converter
        [HttpGet]
       
        public ActionResult Converter()
        { 
            string num = Request.QueryString["num"];
            string type = Request.QueryString["type"];

            ViewBag.num = num;
            ViewBag.type = type;
            if (!String.IsNullOrEmpty(num))
            {
                if (type.StartsWith("a"))
                {
                    ViewBag.a = Convert.ToDouble(num);
                    ViewBag.b = ViewBag.a * 1609344;
                    ViewBag.c = ViewBag.a * 160934.4;
                    ViewBag.d = ViewBag.a * 1609.34;
                    ViewBag.e = ViewBag.a * 1.60934;
                    return View("Result");
                }

                else if (type[0] == 'b')
                {
                    ViewBag.b = Convert.ToDouble(num);
                    ViewBag.a = ViewBag.d * 0.00062;
                    ViewBag.c = ViewBag.b * 0.1;
                    ViewBag.d = ViewBag.b * 0.001;
                    ViewBag.e = ViewBag.b * 0.000001;
                    return View("Result");
                }

                else if (type[0] == 'c')
                {
                    ViewBag.c = Convert.ToDouble(num);
                    ViewBag.a = ViewBag.e * 0.6214;
                    ViewBag.b = ViewBag.c * 10;
                    ViewBag.d = ViewBag.c * 0.01;
                    ViewBag.e = ViewBag.c * 0.00001;
                    return View("Result");
                }

                else if (type[0] == 'd')
                {
                    ViewBag.d = Convert.ToDouble(num);
                    ViewBag.a = ViewBag.e * 0.6214;
                    ViewBag.b = ViewBag.d * 1000;
                    ViewBag.c = ViewBag.d * 100;
                    ViewBag.e = ViewBag.d * 0.001;
                    return View("Result");
                }

                else if (type[0] == 'e')
                {
                    ViewBag.e = Convert.ToDouble(num);
                    ViewBag.a = ViewBag.e * 0.6214;
                    ViewBag.b = ViewBag.e * 1000000;
                    ViewBag.c = ViewBag.e * 100000;
                    ViewBag.d = ViewBag.e * 1000;
                    return View("Result");
                }
                else
                {
                    ViewBag.ErrorMessage("Invalid input");
                    return View();
                }

            }


            return View();
        }
    }
}