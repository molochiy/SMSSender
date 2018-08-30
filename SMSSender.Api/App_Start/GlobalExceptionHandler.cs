using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using SMSSender.Common.Exceptions;

namespace SMSSender.Api
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context.Exception is AggregateException exception)
            {
                CreateAggregateExceptionResult(context, exception);
            }
            else if (context.Exception is NotFoundException)
            {
                context.Result = new NotFoundResult(context.ExceptionContext.Request);
                return; // do not break in case of a not found
            }
            else
            {
                context.Result = new TextPlainErrorResult(HttpStatusCode.InternalServerError)
                {
                    Request = context.ExceptionContext.Request,
                    Content = "An unexpected server error occurred. Please notify a system " +
                              "administrator or check the logs for details."
                };
            }

#if DEBUG
            if (Debugger.IsAttached && !(context.Exception is TaskCanceledException) &&
                !(context.Exception.InnerException is TaskCanceledException))
            {
                Debugger.Break();
            }
#endif
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }

        private static void CreateAggregateExceptionResult(
            ExceptionHandlerContext context,
            AggregateException aggregate)
        {
            string errors = string.Empty;
            if (aggregate != null)
            {
                foreach (Exception innerException in aggregate.InnerExceptions)
                {
                    errors += innerException.Message + ";";
                }
            }

            context.Result = new TextPlainErrorResult(HttpStatusCode.BadRequest)
            {
                Request = context.ExceptionContext.Request,
                Content = "The following errors occured: " + errors
            };
        }

        private class TextPlainErrorResult : IHttpActionResult
        {
            private readonly HttpStatusCode _httpStatusCode;

            public TextPlainErrorResult(HttpStatusCode httpStatusCode)
            {
                _httpStatusCode = httpStatusCode;
            }

            public HttpRequestMessage Request { private get; set; }

            public string Content { private get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var response = new HttpResponseMessage(_httpStatusCode)
                {
                    Content = new StringContent(Content),
                    RequestMessage = Request
                };

                return Task.FromResult(response);
            }
        }
    }
}