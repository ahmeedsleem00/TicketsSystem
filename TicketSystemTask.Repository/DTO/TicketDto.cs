using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemTask.Repository.DTO
{
    public class TicketDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Phone]
        public string MobileNumber { get; set; } 

        [Required]
        public string TicketNumber { get; set; }
    }
}
