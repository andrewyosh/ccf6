using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Predictive_Diversion_Control.Models
{
    public class OverdosesModel
    {        
            public int count { get; set; }
            public string location_1_city { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }        
    }
}