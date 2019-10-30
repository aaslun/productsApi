using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using ProductApi.Exceptions;
using Umbraco.Core.Logging;

namespace ProductApi.Attributes
{
    public class ApiActionExceptionAttribute : ExceptionFilterAttribute
    {
        private ILogger _logger;

        public ApiActionExceptionAttribute(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

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
                    _logger.Debug<ApiActionExceptionAttribute>($"Entity not found {entityNotFoundException.EntityType}");
                }
                else
                {
                    _logger.Debug<ApiActionExceptionAttribute>("Entity not found");
                }

                context.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            if (context.Exception is BadRequestException badRequestException)
            {
                _logger.Warn<ApiActionExceptionAttribute>("Bad request");

                context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
