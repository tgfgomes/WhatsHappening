using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhatsHappening.Models.Events
{
    public class EventCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        //System.Data.Entity.Spatial.DbGeography gpsLocation { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public IEnumerable<DateTime> EventDates { get; set; }
        //public IEnumerable<ICategory> Categories { get; private set; }
    }
}