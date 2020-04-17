using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message =null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? DefaultErrorMessages(statusCode);

        }

        private string DefaultErrorMessages(int statusCode)
        {
           return statusCode switch {
               400 => "A Bad Request",
               401 => "UnAuthorized",
               404 => "Not Found",
               500 => "Server Error", 
               _ => null
           };
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }
    }
}