using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Model
{
    public class TimeCodes
    {
        //[JsonProperty("CoyCode")]
        public string CoyCode { get; set; }
        //[JsonProperty("TimeCode")]
        public string TimeCode { get; set; }
        //[JsonProperty("TimeCodeDescription")]
        public string TimeCodeDescription { get; set; }
        //[JsonProperty("TimeCodeChargeRate")]
        public decimal TimeCodeChargeRate { get; set; }
        //[JsonProperty("DefaultVAT")]
        public bool DefaultVAT { get; set; }
    }
}
