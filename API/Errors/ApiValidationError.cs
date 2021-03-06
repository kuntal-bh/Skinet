
using System.Collections.Generic;

namespace API.Errors
{
    public class ApiValidationError : ApiResponse
    {
        public ApiValidationError(int statusCode) : base(400)
        {
            
        }

        public IEnumerable<string> ValidationErrors { get; set; }
    }
}