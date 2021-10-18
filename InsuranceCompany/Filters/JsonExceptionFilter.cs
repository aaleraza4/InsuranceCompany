using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<JsonExceptionFilter> logger;
        public JsonExceptionFilter(ILogger<JsonExceptionFilter> logger)
        {
            this.logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.ContentType = "application/json";
            logger.LogError(context.Exception, context.Exception.GetBaseException().Message);
            context.Result = new ObjectResult(new { status = false, msg = "Unable to process your request, please contact admin." });
        }
    }
}
