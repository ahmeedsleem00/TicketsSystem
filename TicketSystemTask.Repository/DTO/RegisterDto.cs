using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystemTask.Repository.DTO
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }
      
        [Required]
        [RegularExpression(pattern: "^(?=^.{6,10}$)(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%&amp;*()_+]).*$",
            ErrorMessage = "Password Must be Contains 1 Uppercase, 1 Lowercase , 1 Digit, 1 Special Character")]

        public string Password { get; set; }
    }
}
