using System.Collections.Generic;

namespace SouthWestContractors.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(bool success, string message)
        {
            Success=success;
            Message=message;
        }

        public BaseResponse(string message = null)
        {
            Success = true;
            Message = message;

        }

        public bool Success { get; set; }
        public string Message { get; set; }
        //reforzar
        public List<string> ValidationErrors { get; set; }

    }
}
