using Core.Utilities.Messages;

namespace Core.Utilities.Responses
{
    public class ErrorApiDataResponse<T> : ApiDataResponse<T>
    {
        public ErrorApiDataResponse(T data, string message, bool success=false, ResultCodes resultCodes=ResultCodes.HTTP_InternalServerError, int resultCount=0) 
            : base(data, message, success, resultCodes, resultCount)
        {
        }
    }
}