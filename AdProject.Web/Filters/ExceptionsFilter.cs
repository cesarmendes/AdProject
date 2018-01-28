using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdProject.Web.Filters
{
    public class ExceptionsFilter : IExceptionFilter
    {
        ILogger<ExceptionsFilter> Logger { get; set; }
        public ExceptionsFilter(ILogger<ExceptionsFilter> logger)
        {
            Logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.ActionDescriptor is ControllerActionDescriptor)
            {
                var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            }
            else
            {
            }


            var sb = new StringBuilder();


            var ex = context.Exception;


            Logger.LogError(ex, "");

        }
    }
}
