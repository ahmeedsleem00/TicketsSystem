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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
           return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByMobileNumberAsync(string mobileNumber)
        {
            return  await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == mobileNumber);
            
        }
    }
}
