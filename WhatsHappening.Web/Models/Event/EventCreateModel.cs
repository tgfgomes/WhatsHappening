using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatsHappening.Web.Models.Event
{
    public class EventCreateModel
    {
        [Required]
        [Display(Name = "Event Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        public DateTime? EventDate { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        //System.Data.Entity.Spatial.DbGeography gpsLocation { get; set; }
        [Display(Name = "Country")]
        public IEnumerable<SelectListItem> CountryList { get; set; }
        [Required]
        public Guid? SelectedCountryId { get; set; }
        [Display(Name = "City")]
        public IEnumerable<SelectListItem> CityList { get; set; }
        [Required]
        public Guid? SelectedCityId { get; set; }
        [Display(Name = "Categories")]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        [Required]
        public Guid? SelectedCategoryId { get; set; }

        //?????
        //[Display(Name = "Categories")]
        //public IEnumerable<SelectListItem> TagsList { get; private set; }
    }
}