using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystemTask.Core.Models;
using TicketSystemTask.Repository.Interfaces;

namespace TicketSystemTask.Repository.Implementations
{
    internal class Register : IUserRegister
    {
        private readonly ApplicationDbContext _context;

        public Register(ApplicationDbContext context)
        {
            this._context = context;
        }

     

        public async Task CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

       

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            return await _context.Users
                          .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }
    }
}
