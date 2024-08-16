using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystemTask.Core.Models;

namespace TicketSystemTask.Repository.Interfaces
{
    public interface IUserRegister
    {
        Task CreateUserAsync(User user);
        Task<User> ValidateUserAsync(string username, string password);
    }
}
