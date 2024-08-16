using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystemTask.Core.Models;
using TicketSystemTask.Services.Interfaces;

namespace TicketSystemTask.Repository.Implementations
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _context.Tickets.Include(t => t.User)
                                         .OrderByDescending(t => t.TicketNumber).ToListAsync();
        }

        public async Task CreateTicketAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
        }



        public Task<Ticket> GetAllTicketsOrderedByNumberAsync(string mobileNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket> GetTicketByNumberAsync(string ticketNumber)
        {
            return await _context.Tickets.FirstOrDefaultAsync(t => t.TicketNumber == ticketNumber);

        }
    }

}
