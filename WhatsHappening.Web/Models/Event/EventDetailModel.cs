using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhatsHappening.Web.Models.Event
{
    public class EventDetailModel
    {
        public Guid EventId { get; set; }
        [Display(Name = "Event Name")]
        public string Name { get; set; }
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        //System.Data.Entity.Spatial.DbGeography gpsLocation { get; set; }
        [Display(Name = "Country")]
        public string CountryName { get; set; }
        [Display(Name = "City")]
        public string CityName { get; set; }
        [Display(Name = "Categories")]
        public IEnumerable<string> CategoryList { get; set; }
    }
}