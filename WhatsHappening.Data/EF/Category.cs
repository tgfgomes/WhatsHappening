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
    
    public partial class Category
    {
        public Category()
        {
            this.Event = new HashSet<Event>();
        }
    
        public System.Guid id { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<Event> Event { get; set; }
    }
}
