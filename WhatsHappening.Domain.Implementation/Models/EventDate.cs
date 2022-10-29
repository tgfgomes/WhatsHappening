using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsHappening.Domain.Models.RW;

namespace WhatsHappening.Domain.Implementation.Models
{
    public class EventDate : IEventDateRW
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

    }
}
