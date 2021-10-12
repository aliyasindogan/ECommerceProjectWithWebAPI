namespace Core.Utilities.Responses
{
    public class ErrorApiResponse : ApiResponse
    {
        public ErrorApiResponse() : base(success: false)
        {
        }

        public ErrorApiResponse(string message) : base(success: false, message: message)
        {
        }
    }
}