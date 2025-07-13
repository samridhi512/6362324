using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace webapi3.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            File.AppendAllText("error_log.txt", context.Exception.ToString());

            context.Result = new ObjectResult("An error occurred. Please try again.")
            {
                StatusCode = 500
            };
        }
    }
}
