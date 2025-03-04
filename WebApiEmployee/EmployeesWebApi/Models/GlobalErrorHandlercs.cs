using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesWebApi.Models
{
    public class GlobalErrorHandlercs : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try 
            {
                await next(context);
            }
            catch (Exception ex)
            {
                ProblemDetails details = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Detail = ex.Message,
                    Type="Internal Server Error",
                    Title ="Server Error"


                };
                //serialize the problem details into json
                var json = JsonSerializer.Serialize(details);
                //write the json error in the httpcontext response
                context.Response.ContentType = "application/json";
               await context.Response.WriteAsync(json);
             }
           
        }
    }
}
