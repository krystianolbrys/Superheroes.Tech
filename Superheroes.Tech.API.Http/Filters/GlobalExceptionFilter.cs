using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Superheroes.Tech.Domain.Core.Exceptions;

namespace Superheroes.Tech.API.Http.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // log to extranl system for distributed tracking, add correlationId or something for that microservice

            if (context.Exception is BusinessException businessException)
            {
                context.Result = new ObjectResult(new
                {
                    Message = businessException.Message,
                    ExceptionType = businessException.GetType().Name
                })
                {
                    StatusCode = 400
                };
            }
            else
            {
                context.Result = new ObjectResult(new
                {
                    Message = "An unexpected error occurred while processing your request.",
                })
                {
                    StatusCode = 500
                };
            }
        }
    }
}
