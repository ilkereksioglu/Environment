using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EnvironmentAPI.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger) 
        { 
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items["RequestId"] = Guid.NewGuid();
            context.HttpContext.Items["ActionArguments"] = context.ActionArguments != null 
                ? String.Join(", ", context.ActionArguments.Select(kvp => kvp.Key + ": " + kvp.Value)) 
                : String.Empty;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(
                $"RequestId: {context.HttpContext.Items["RequestId"]}. " +
                $"ActionParamters: {context.HttpContext.Items["ActionArguments"]}. " +
                $"ErrorMessage: {context.Exception.Message}. " +
                $"ErrorSource: {context.Exception.Source}. " +
                $"StackTrace: {context.Exception.StackTrace}. " +
                $"InnerException: {context.Exception.InnerException}");
            context.HttpContext.Items["ActionArguments"] = null;
            context.ExceptionHandled = true;
            context.Result = new ContentResult
            {
                Content = context.Exception.ToString()
            };
        }
    }
}
