using Core.Utilities.Messages;

namespace Core.Utilities.Responses
{
    public class ApiResponse
    {
        public ApiResponse(string message, bool success, ResultCodes resultCodes, int resultCount)
        {
            Success = success;
            Message = message;
            ResultCount = resultCount;
            ResultCode = (int)resultCodes;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public int ResultCount { get; set; }
        public int ResultCode { get; set; }
    }
}