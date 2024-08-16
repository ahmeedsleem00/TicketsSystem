using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystemTask.Core.Models;
using TicketSystemTask.Repository.Data;
using TicketSystemTask.Services.Interfaces;

namespace TicketSystemTask.Services
{
    public class TicketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public User[] Users { get; set; }

        public TicketService()
        {
            Users = Seed.SeedUsers();
            
        }

        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        private void CreateTickets()
        {
            foreach (var user in Users)
            {
                user.Ticket = new Ticket
                {
                    Id = user.Id, 
                    TicketNumber = GenerateTicketNumber(),
                    UserId = user.Id,
                    User = user
                };
            }
        }
        private string GenerateTicketNumber()
        {
            return Guid.NewGuid().ToString();
        }

        public void DisplayTickets()
        {
            foreach (var user in Users)
            {

                if (user.Ticket != null)
                {
                    Console.WriteLine($"User: {user.Name}, Mobile: {user.PhoneNumber}, Ticket Number: {user.Ticket.TicketNumber}");
                }
                else
                {
                    Console.WriteLine($"User: {user.Name}, Mobile: {user.PhoneNumber}, has no ticket assigned.");
                }
            }
        }
    }
}
