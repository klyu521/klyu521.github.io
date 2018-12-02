using hw8.Models;
using hw8.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace hw8.Controllers
{
    public class ItemsController : Controller
    {
        private AuctionContext db = new AuctionContext();


        public ActionResult HomePage()
        {
            var bids = db.Bids.Take(10).OrderByDescending(x => x.TimeStamp);

            return View(bids.ToList());

        }
        // GET: Auction
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Seller1);
            return View(items.ToList());
        }

        // GET: Bids/Create
        public ActionResult CreateBid()
        {
            ViewBag.Buyer = new SelectList(db.Buyers, "Name", "Name");
            ViewBag.ItemID = new SelectList(db.Items, "ID", "Name");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBid([Bind(Include = "ID,ItemID,Buyer,Price,TimeStamp")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Buyer = new SelectList(db.Buyers, "Name", "Name", bid.Buyer);
            ViewBag.ItemID = new SelectList(db.Items, "ID", "Name", bid.ItemID);
            return View(bid);
        }

        // GET: Auction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AuctionVM vm = new AuctionVM()
            {
                VmItem = db.Items.Find(id)
            };

            if (vm.VmItem == null)
            {
                return HttpNotFound();
            }

            return View(vm);
        }

        // GET: Auction/Create
        public ActionResult Create()
        {
            ViewBag.Seller = new SelectList(db.Sellers, "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Seller")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Seller = new SelectList(db.Sellers, "Name", "Name", item.Seller);
            return View(item);
        }

        // GET: Auction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.Seller = new SelectList(db.Sellers, "Name", "Name", item.Seller);
            return View(item);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Seller")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Seller = new SelectList(db.Sellers, "Name", "Name", item.Seller);
            return View(item);
        }

      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);

            List<Bid> bids = db.Bids.Where(x => x.ItemID == id).ToList();

            if (bids.Count == 0)
            {
                foreach (Bid bid in bids)
                {
                    db.Bids.Remove(bid);
                }
            }

            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}