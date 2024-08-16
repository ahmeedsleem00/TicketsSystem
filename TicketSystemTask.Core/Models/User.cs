using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemTask.Core.Models
{
    public class User 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Password { get; set; }
        public Ticket? Ticket { get; set; }

    }
}
