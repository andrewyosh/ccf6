using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Predictive_Diversion_Control.Models
{
    public class TreatmentCenterModel
    {
        public string ProgramName { get; set; }
        public string DBA { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public double latitude { get; set; }
        public double longitude{get;set;}
    }
}