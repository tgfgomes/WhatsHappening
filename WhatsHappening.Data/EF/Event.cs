//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WhatsHappening.Data.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public Event()
        {
            this.EventDates = new HashSet<EventDates>();
            this.Category = new HashSet<Category>();
        }
    
        public System.Guid id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public System.Guid cityId { get; set; }
        public System.Data.Entity.Spatial.DbGeography gpsLocation { get; set; }
        public System.DateTime creationDate { get; set; }
        public System.DateTime lastUpdateDate { get; set; }
    
        public virtual City City { get; set; }
        public virtual ICollection<EventDates> EventDates { get; set; }
        public virtual ICollection<Category> Category { get; set; }
    }
}
