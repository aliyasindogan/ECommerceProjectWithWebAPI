using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Localization;
using Core.Utilities.Messages;
using Core.Utilities.Responses;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            var type = e.GetType();
            ILocalizationService _localizationService = (ILocalizationService)httpContext.RequestServices.GetService(typeof(ILocalizationService));
            FileLogger fileLogger = new FileLogger();
            string message = String.Empty;
            ErrorApiResponse errorApiResponse = new ErrorApiResponse(message: "Internal Server Error", resultCodes: ResultCodes.HTTP_InternalServerError);

            IEnumerable<ValidationFailure> errors;
            if (e.GetType() == typeof(ValidationException))
            {
                errors = ((ValidationException)e).Errors;
                string dataError = "";
                foreach (var itemError in errors)
                {
                    dataError += _localizationService[itemError.ErrorCode] + ";";
                }
                errorApiResponse = new ErrorApiResponse(dataError, resultCodes: ResultCodes.HTTP_BadRequest);
                fileLogger.Error($"{errorApiResponse} StackTrace:{e.StackTrace} Message:{e.Message}");
            }
            else
            if (e.GetType() == typeof(UnauthorizedAccessException))
            {
                errorApiResponse = new ErrorApiResponse("Unauthorized", resultCodes: ResultCodes.HTTP_Unauthorized);
                fileLogger.Error($"{errorApiResponse} StackTrace:{e.StackTrace} Message:{e.Message}");
            }
            else
            if (e.GetType() == typeof(KeyNotFoundException))
            {
                errorApiResponse = new ErrorApiResponse("Error Not Found", resultCodes: ResultCodes.HTTP_NotFound);
                fileLogger.Error($"{errorApiResponse} StackTrace:{e.StackTrace} Message:{e.Message}");
            }else
            if (e.GetType() == typeof(Exception))
            {
                errorApiResponse = new ErrorApiResponse("Internal Server Error", resultCodes: ResultCodes.HTTP_InternalServerError);
                fileLogger.Error($"{errorApiResponse} StackTrace:{e.StackTrace} Message:{e.Message}");
            }
            else
            {
                fileLogger.Error($"{errorApiResponse} StackTrace:{e.StackTrace} Message:{e.Message}");
            }

            var result = JsonSerializer.Serialize(errorApiResponse, new JsonSerializerOptions() { PropertyNamingPolicy = null });

            return httpContext.Response.WriteAsync(result);
        }
    }
}