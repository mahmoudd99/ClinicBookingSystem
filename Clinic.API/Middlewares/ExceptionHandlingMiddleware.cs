using Clinic.Application.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Clinic.API.Middlewares
{
   
        public class ExceptionHandlingMiddleware
        {
            private readonly RequestDelegate _next;

            public ExceptionHandlingMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (FluentValidation.ValidationException ex)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "application/json";

                    var response = new
                    {
                        Success = false,
                        Message = "Validation Failed",
                        Errors = ex.Errors.Select(e => e.ErrorMessage)
                    };

                    await context.Response.WriteAsync(
                        JsonSerializer.Serialize(response));
                }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    Success = false,
                    Message = ex.Message
                };

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response));
            }
            catch (BusinessException ex)
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    Success = false,
                    Message = ex.Message
                };

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response));
            }

            catch (Exception)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";

                    var response = new
                    {
                        Success = false,
                        Message = "Internal Server Error"
                    };

                    await context.Response.WriteAsync(
                        JsonSerializer.Serialize(response));
                }
            }
        }




    
}
