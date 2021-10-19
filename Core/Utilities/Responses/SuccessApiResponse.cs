using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Responses
{
    public class SuccessApiResponse : ApiResponse
    {
        public SuccessApiResponse() : base(success: true)
        {
        }

        public SuccessApiResponse(string message) : base(success: true, message: message)
        {
        }
    }
}