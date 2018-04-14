using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using Geocoding.Google;
using Geocoding.Microsoft;
using Predictive_Diversion_Control.Models;

namespace Predictive_Diversion_Control
{    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<OverdosesModel> heroinOverdoseList = new List<OverdosesModel>();
            List<OverdosesModel> prescriptionOverdoseList = new List<OverdosesModel>();
            var waTreatmentCenters = new List<TreatmentCenterModel>();

            using (StreamReader sr = new StreamReader(Server.MapPath("~/Controllers/heroin.json")))
            {
                heroinOverdoseList = JsonConvert.DeserializeObject<List<OverdosesModel>>(sr.ReadToEnd());
            }

            using (StreamReader sr = new StreamReader(Server.MapPath("~/Controllers/prescription.json")))
            {
                prescriptionOverdoseList = JsonConvert.DeserializeObject<List<OverdosesModel>>(sr.ReadToEnd());
            }
            
            using (StreamReader sr = new StreamReader(Server.MapPath("~/Controllers/waTreatmentCenters.json")))
            {
                waTreatmentCenters = JsonConvert.DeserializeObject<List<TreatmentCenterModel>>(sr.ReadToEnd());
            }

            encapData encap = new encapData();
            encap.heroinOverdoseList = heroinOverdoseList;
            encap.prescriptionOverdoseList = prescriptionOverdoseList;
            encap.waTreatmentCenters = waTreatmentCenters;

            //GoogleGeocoder geocoder = new GoogleGeocoder("AIzaSyC5T01Azye6mJJ1XNVyDvDm5QIhLSOIrWE");
            //BingMapsGeocoder bingGeocoder = new BingMapsGeocoder("AjFkeZcTp7ZICdShwZucozyyTwGD4wniT0Gn9d5z7WnoN0ytlugmJYsk7wYLshkC");

            //var json = new List<string>();

            //foreach (var x in waTreatmentCenters)
            //{
            //    try
            //    {
            //        IEnumerable<GoogleAddress> address = await geocoder.GeocodeAsync(x.Street + "," + x.Zipcode + " " + x.City + " " + x.State);
            //        var longitude = address.Select(a => a.Coordinates.Longitude).FirstOrDefault();
            //        var latitude = address.Select(a => a.Coordinates.Latitude).FirstOrDefault();
            //        x.latitude = latitude;
            //        x.longitude = longitude;
            //    }

            //    catch (Exception e)
            //    {
            //        IEnumerable<BingAddress> address = await bingGeocoder.GeocodeAsync(x.Street + "," + x.Zipcode + " " + x.City + " " + x.State);
            //        var longitude = address.Select(a => a.Coordinates.Longitude).FirstOrDefault();
            //        var latitude = address.Select(a => a.Coordinates.Latitude).FirstOrDefault();
            //        x.latitude = latitude;
            //        x.longitude = longitude;
            //    }

            //}

            //string serializeJson = JsonConvert.SerializeObject(waTreatmentCenters);
            //System.IO.File.WriteAllText(@"C:\Users\nynph\Desktop\waTreatmentCenters.json", serializeJson);

            //ViewBag.Message = country.FormattedAddress;
            return View(encap);
        }
    }
}