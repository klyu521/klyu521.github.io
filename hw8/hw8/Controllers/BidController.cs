﻿using hw8.Models;
using hw8.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hw8.Controllers
{
    public class BidController : Controller
    {
        private AuctionContext db = new AuctionContext();
        public JsonResult ItemBids(int? id)
        {

            AuctionVM vm = new AuctionVM
            {
                //Find the Item with the id
                VmItem = db.Items.Find(id)
            };

            string jsonObj = "";

            //Checks if the Item has a bid. 
            if (vm.VmItem.Bids.Count > 0)
            {

                //Item ID that has a bid
                int pid = vm.VmItem.Bids.FirstOrDefault().ItemID;

                //Assign it to the bid
                vm.VMBid = db.Items.SelectMany(x => x.Bids)
                                    .Where(i => i.ItemID == pid)
                                    .OrderBy(t => t.TimeStamp)
                                    .ToList();

                jsonObj = JsonConvert.SerializeObject(vm.VMBid);
            }

            //Send it back
            return Json(jsonObj, JsonRequestBehavior.AllowGet);
        }
    }
}