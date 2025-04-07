using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using ILogger = Serilog.ILogger;
using System;
using System.Diagnostics;
namespace Parsyn.Apps.Api.Core.Handlers.Exception
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger logger;
        public ExceptionHandler(ILogger logger)
        {
            this.logger = logger;
        }
        public ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
             System.Exception exception,
            CancellationToken cancellationToken)
        {
            var exceptionMessage = exception.Message;
            logger.Error(
                "Error Message: {exceptionMessage}, Time of occurrence {time}",
                exceptionMessage, DateTime.UtcNow);

            // Return false to continue with the default behavior
            // - or - return true to signal that this exception is handled
            return ValueTask.FromResult(false);
        }


    }
}
