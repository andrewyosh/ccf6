using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccf6.Models;
using Geocoding.Google;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ccf6.Controllers
{    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public  ActionResult GatherDataAsync()
        {
            using (StreamReader sr = new StreamReader(Server.MapPath("~/Controllers/heroin.json")))
            {
                var heroinOverdoseList= JsonConvert.DeserializeObject<List<OverdosesModel>>(sr.ReadToEnd());
            }
            using (StreamReader sr = new StreamReader(Server.MapPath("~/Controllers/prescription.json")))
            {
                var prescriptionOverdoseList = JsonConvert.DeserializeObject<List<OverdosesModel>>(sr.ReadToEnd());
            }

            GoogleGeocoder geocoder = new GoogleGeocoder();
  
            //ViewBag.Message = country.FormattedAddress;
            return View();
        }        
    }
}