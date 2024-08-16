using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystemTask.Core.Models;

namespace TicketSystemTask.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByMobileNumberAsync(string mobileNumber);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
