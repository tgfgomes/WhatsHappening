using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHappening.Domain.Models.RW
{
    public interface IEventDateRW : IEventDate
    {
        new Guid Id { get; set; }
    }
}
