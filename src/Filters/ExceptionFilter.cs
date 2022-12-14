using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Tryitter.src.Exceptions;

namespace Tryitter.src.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                var exception = context.Exception;
                var statusCode = true switch
                {
                    bool _ when exception is UnauthorizedException => (int)HttpStatusCode.Unauthorized,
                    bool _ when exception is NotFoundException => (int)HttpStatusCode.NotFound,
                    bool _ when exception is ConflictException => (int)HttpStatusCode.Conflict,
                    bool _ when exception is InvalidOperationException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError,
                };
                context.Result = new ObjectResult(exception.Message) { StatusCode = statusCode };
            }
        }
    }
}
