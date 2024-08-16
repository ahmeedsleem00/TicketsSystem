using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystemTask.Core.Models;
using TicketSystemTask.Repository;
using TicketSystemTask.Repository.Implementations;

namespace TicketSystemTask.Services.Interfaces
{
    public interface IUnitOfWork 
    {
        IUserRepository Users { get; }
        ITicketRepository Tickets { get; }
        Task<int> CompleteAsync();
    }

    public class UnitOfWork : IUnitOfWork

    {
        private readonly ApplicationDbContext _context;
        private IUserRepository _users;
        private ITicketRepository _tickets;



       public IUserRepository Users => _users ??= new UserRepository(_context);

        public ITicketRepository Tickets => _tickets ??= new TicketRepository(_context);

        public UnitOfWork(ApplicationDbContext context, IRepository<User> userRepository, IRepository<Ticket> ticketRepository)
        {
            _context = context;
           
        }

       


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
