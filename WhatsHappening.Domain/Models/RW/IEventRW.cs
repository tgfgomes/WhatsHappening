using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHappening.Domain.Models.RW
{
    public interface IEventRW : IEvent
    {
        new Guid Id { get; set; }
        new DateTimeOffset CreationDate { get; set; }
        new DateTimeOffset LastUpdateDate { get; set; }
        //new ILocation Location { get; set; }
    }
}
