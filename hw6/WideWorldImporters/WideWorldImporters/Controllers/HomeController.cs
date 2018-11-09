using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WideWorldImporters.Models;
using WideWorldImporters.Models.ViewModel;

namespace WideWorldImporters.Controllers
{
    public class HomeController : Controller
    {
        private WWIContext db = new WWIContext();

        public ActionResult Index(String input)
        {
            input = Request.QueryString["input"];
            if (input == null)
            {
                ViewBag.show = false;
                return View();
            }
            else
            {
                ViewBag.show = true;
                return View(db.People.Where(search => search.FullName.Contains(input)).ToList());
            }
        }

        
        public ActionResult Details(int? id)
        {
           
            ViewBag.NotEmployee = false;

            Info vm = new Info();

            vm.Person = db.People.Find(id);

            // Returns 404 if the input ID is not in the database 
            if (id == null || vm.Person == null)
            {
                return HttpNotFound();
            }

            // Check the customer data
            if (vm.Person.Customers2.Count() > 0)
            {
                ViewBag.NotEmployee = true;

                // Get customer ID
                int custID = vm.Person.Customers2.FirstOrDefault().CustomerID;

                // Finds the customer
                vm.Customer = db.Customers.Find(custID);

                // Gets the Gross Sales and Gross Profit for Purchase History table
                ViewBag.GrossSales = vm.Customer.Orders.SelectMany(i => i.Invoices).SelectMany(il => il.InvoiceLines).Sum(ep => ep.ExtendedPrice);
                ViewBag.GrossProfit = vm.Customer.Orders.SelectMany(i => i.Invoices).SelectMany(il => il.InvoiceLines).Sum(lp => lp.LineProfit);

                // Builds a list of top 10 items purchased in descending order by selecting into the invoicelines data table
                vm.InvoiceLine = vm.Customer.Orders.SelectMany(i => i.Invoices)
                                                .SelectMany(il => il.InvoiceLines)
                                                .OrderByDescending(lp => lp.LineProfit)
                                                .Take(10)
                                                .ToList();
            }

           
            return View(vm);
        }
    }
}