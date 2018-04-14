using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ccf6.Models;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Geocoding.Google;
using Geocoding.Microsoft;
using Predictive_Diversion_Control.Models;

namespace ccf6.Controllers
{    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> GatherDataAsync()
        {
            using (StreamReader sr = new StreamReader(Server.MapPath("~/Controllers/heroin.json")))
            {
                var heroinOverdoseList= JsonConvert.DeserializeObject<List<OverdosesModel>>(sr.ReadToEnd());
            }
            using (StreamReader sr = new StreamReader(Server.MapPath("~/Controllers/prescription.json")))
            {
                var prescriptionOverdoseList = JsonConvert.DeserializeObject<List<OverdosesModel>>(sr.ReadToEnd());
            }
            var waTreatmentCenters = new List<TreatmentCenterModel>();

            using (StreamReader sr = new StreamReader(Server.MapPath("~/Controllers/waTreatmentCenters.json")))
            {
                waTreatmentCenters = JsonConvert.DeserializeObject<List<TreatmentCenterModel>>(sr.ReadToEnd());
            }

            GoogleGeocoder geocoder = new GoogleGeocoder("AIzaSyC5T01Azye6mJJ1XNVyDvDm5QIhLSOIrWE");
            BingMapsGeocoder bingGeocoder = new BingMapsGeocoder("AjFkeZcTp7ZICdShwZucozyyTwGD4wniT0Gn9d5z7WnoN0ytlugmJYsk7wYLshkC");

            var json = new List<string>();

            foreach (var x in waTreatmentCenters)
            {
                try
                {
                IEnumerable<GoogleAddress> address = await geocoder.GeocodeAsync(x.Street + "," + x.Zipcode + " " + x.City + " " + x.State);
                var longitude = address.Select(a => a.Coordinates.Longitude).FirstOrDefault();
                var latitude = address.Select(a => a.Coordinates.Latitude).FirstOrDefault();
                x.latitude = latitude;
                x.longitude = longitude;
                }

                catch (Exception e)
                {
                    IEnumerable<BingAddress> address = await bingGeocoder.GeocodeAsync(x.Street + "," + x.Zipcode + " " + x.City + " " + x.State);
                    var longitude = address.Select(a => a.Coordinates.Longitude).FirstOrDefault();
                    var latitude = address.Select(a => a.Coordinates.Latitude).FirstOrDefault();
                    x.latitude = latitude;
                    x.longitude = longitude;
                }
                
            }         
            //ViewBag.Message = country.FormattedAddress;
            return View();
        }        
    }
}