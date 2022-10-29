using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHappening.Domain.Models
{
    public interface IEventDate
    {
        Guid Id { get; }
        DateTime Date { get; set; }


        //IEvent Event { get; }
    }
}
