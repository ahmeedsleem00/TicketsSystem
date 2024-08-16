using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystemTask.Core.Models;

namespace TicketSystemTask.Repository.Data
{
    public static class DataSeeding
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Ahmed", PhoneNumber = "01157084165" },
                new User { Id = 2, Name = "Mohamed", PhoneNumber = "01234580797" },
                new User { Id = 3, Name = "Omar", PhoneNumber = "01047878945" },
                new User { Id = 4, Name = "Hassan", PhoneNumber = "01546864548" },
                new User { Id = 5, Name = "Sayed", PhoneNumber = "01254678654" },
                new User { Id = 6, Name = "Mahmoud", PhoneNumber = "01246084846" },
                new User { Id = 7, Name = "Diaa", PhoneNumber = "01157876484" },
                new User { Id = 8, Name = "Nada", PhoneNumber = "01576864656" },
                new User { Id = 9, Name = "Sara", PhoneNumber = "01546765165" },
                new User { Id = 10, Name = "Amin", PhoneNumber = "01154676470" }

                );
 
              
        }
    }

}
