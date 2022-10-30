using Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Responses
{
    public class ApiDataResponse<T> : ApiResponse
    {
        public ApiDataResponse(T data,string message, bool success, ResultCodes resultCodes, int resultCount) : base(message, success, resultCodes, resultCount)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}