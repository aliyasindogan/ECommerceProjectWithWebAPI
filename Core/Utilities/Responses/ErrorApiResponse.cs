using Core.Utilities.Messages;

namespace Core.Utilities.Responses
{
    public class ErrorApiResponse : ApiResponse
    {
        public ErrorApiResponse(string message, bool success=false, ResultCodes resultCodes=ResultCodes.HTTP_InternalServerError, int resultCount=0) : base(message, success, resultCodes, resultCount)
        {
        }
    }
}