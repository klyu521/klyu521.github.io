using hw7.DAL;
using hw7.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace hw7.Controllers
{
    public class TranslatorController : Controller
    {
        private LogContext db = new LogContext();


        public JsonResult Sticker(string id)
        {
           
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["APIKEY"];



            string url = "https://api.giphy.com/v1/stickers/translate?api_key=" + apiKey + "&s=" + id;

            Debug.WriteLine(url);


            WebRequest request = WebRequest.Create(url);
            WebResponse getResponce = request.GetResponse();

            Stream giphyStream = WebRequest.Create(url).GetResponse().GetResponseStream();


            var giphyData = new System.Web.Script.Serialization.JavaScriptSerializer()
                                  .Deserialize<Object>(new StreamReader(giphyStream)
                                  .ReadToEnd());




            LogData item = new LogData();
            item.IPAddress = Request.UserHostAddress;
            item.Request = id;
            item.ClientBrowser = Request.UserAgent;
            db.Log.Add(item);
            db.SaveChanges();

            //giphyStream.Close();

            return Json(giphyData, JsonRequestBehavior.AllowGet);
        }
    }
}