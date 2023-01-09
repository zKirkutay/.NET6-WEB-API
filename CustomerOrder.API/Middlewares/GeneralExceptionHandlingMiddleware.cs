using CustomerOrder.Service.Validations;
using FluentValidation.Results;
using System.Net;
namespace CustomerOrder.API.Middlewares
{
    public class GeneralExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GeneralExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await HandleException(context, error);
            }
        }

        private Task HandleException(HttpContext context, Exception error)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = error.Message/*"Internal Server Error"*/;
            IEnumerable<ValidationFailure> errors;
            if (error.GetType() == typeof(FluentValidation.ValidationException))
            {
                message = error.Message;
                errors = ((FluentValidation.ValidationException)error).Errors;
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return context.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = message,
                    Errors = errors
                }.ToString());
            }

            return context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }

    }
}
