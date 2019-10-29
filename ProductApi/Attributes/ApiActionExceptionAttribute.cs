using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using ProductApi.Exceptions;

namespace ProductApi.Attributes
{
    public class ApiActionExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Exception is EntityNotFoundException entityNotFoundException)
            {
                if (entityNotFoundException.EntityType != null)
                {
                    // TODO: log entityNotFoundException.EntityType + entityNotFoundException.Message
                }
                else
                {
                    // TODO: log entityNotFoundException.Message
                }

                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            if (context.Exception is BadRequestException badRequestException)
            {
                // TODO: log badRequestException.Message
                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
