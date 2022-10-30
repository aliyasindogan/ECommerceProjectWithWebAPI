using Core.Utilities.Messages;

namespace Core.Utilities.Responses
{
    public class SuccessApiDataResponse<T> : ApiDataResponse<T>
    {
        public SuccessApiDataResponse(T data, string message, bool success=true, ResultCodes resultCodes=ResultCodes.HTTP_OK, int resultCount=0) : base(data, message, success, resultCodes, resultCount)
        {
        }
    }
}