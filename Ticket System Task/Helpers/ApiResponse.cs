﻿namespace Ticket_System_Task.Helpers
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(StatusCode);
        }

        private string? GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "a bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource was  not found",
                500 => "Server Error",
                _ => null,
            };
        }   
    }
}
