using CatalogService.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CatalogService.WebApi.Filters
{
    public class BusinessLogicExceptionFilter : ExceptionFilterAttribute
    {
        public readonly HttpStatusCode HttpStatusCode;
        private readonly int Code;

        public BusinessLogicExceptionFilter(HttpStatusCode statusCode, int code)
        {
            HttpStatusCode = statusCode;
            this.Code = code;
        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is InvalidOperationException ex)
            {
                context.ExceptionHandled = true;
                context.HttpContext.Response.StatusCode = Code;
                context.Result = new ObjectResult(new ErrorResponse()
                {
                    StatusCode = HttpStatusCode,
                    Message = ex.Message,
                });
                base.OnException(context);
            }
        }
    }
}
