using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystemTask.Core.Models;

namespace TicketSystemTask.Services.Interfaces
{
    public interface ITicketRepository
    {
        Task<Ticket> GetTicketByNumberAsync(string ticketNumber);
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task CreateTicketAsync(Ticket ticket);

    }
}
