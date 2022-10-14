using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Threading.Tasks;

namespace CRUD_V6_MVCCore_Middleware.Models
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        /*private readonly ILogger<ErrorHandlerMiddleware> _logger;*/


        public ErrorHandlerMiddleware(RequestDelegate next/*, ILogger<ErrorHandlerMiddleware> logger*/)
        {
            _next = next;
            /*_logger = logger;*/   
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                 await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                //response.ContentType = "application/json";

                switch (error)
                {
                    case AppException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                response.Redirect("/Employee/Error");
                await _next(context);   
                /*var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);*/


            }
            }
    }
}
