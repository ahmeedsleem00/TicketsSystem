using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemTask.Core.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public DateTime CreatedTime { get; set; }
        public int UserId { get; set; } //fk
        public User User { get; set; }
    }
}
