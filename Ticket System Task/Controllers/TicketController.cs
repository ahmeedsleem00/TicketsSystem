using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_System_Task.Helpers;
using TicketSystemTask.Core.Models;
using TicketSystemTask.Repository.DTO;
using TicketSystemTask.Services.Interfaces;

namespace Ticket_System_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _unitOfWork.Tickets.GetAllTicketsAsync();
            var result = tickets.Select(ticket => new
            {
                ticket.Id,
                ticket.TicketNumber,
                User = new
                {
                    ticket.User.Id,
                    ticket.User.Name,
                    ticket.User.PhoneNumber
                }
            }).ToList();

            return Ok(result);
        }

        [HttpGet("{mobileNumber}")]
        public async Task<IActionResult> GetUserTicket(string mobileNumber)
        {
            var ticket = await _unitOfWork.Users.GetByMobileNumberAsync(mobileNumber);

            if (ticket is null)
            {
                return NotFound(new ApiResponse(statusCode: 404, message: "Product does not exist"));
            }
            return Ok(ticket);
        }

        private string GenerateTicketNumber()
        {
            return $"T-{DateTime.Now.Ticks}";
        }


        //endpoint for create a new ticket
        [HttpPost]
        public async Task<IActionResult> CreateTicket( TicketDto dto)
        {
            var user = await _unitOfWork.Users.GetByMobileNumberAsync(dto.MobileNumber);
            if (user is null)
            {
                return BadRequest("User not found.");
            }
            if (user.Ticket is not null)
            {
                return BadRequest("User already has a ticket.");
            }

            var ticketNumber = GenerateTicketNumber();

            var ticket = new Ticket
            {
                TicketNumber = ticketNumber,
                UserId = user.Id,
                User = user
            };

            await _unitOfWork.Tickets.CreateTicketAsync(ticket);
            await _unitOfWork.CompleteAsync();


            return Ok(new { Message = "Ticket created successfully.", TicketId = ticket.Id });
        

        }

    }
}
