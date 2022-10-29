using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhatsHappening.Web.Models.Event
{
    public class EventSearchModel
    {
        [Display(Name = "Date")]
        public DateTime? EventDate { get; set; }
        [Display(Name = "Location")]
        [Required]
        public string EventLocation { get; set; }
        [Display(Name = "Category")]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public Guid? SelectedCategoryId { get; set; }
    }
}