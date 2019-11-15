using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MaintenancePage.Infrastructure
{
    public class MaintenanceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly MaintenancePage _maintenancePage;

        public MaintenanceMiddleware(RequestDelegate next, MaintenancePage maintenancePage, 
            ILogger<MaintenanceMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _maintenancePage = maintenancePage;
        }

        public async Task Invoke(HttpContext context)
        {
            if (_maintenancePage.Enabled)
            {
                // set the code to 503 for SEO reasons
                context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                context.Response.Headers.Add("Retry-After", _maintenancePage.RetryAfterInSeconds.ToString());
                context.Response.ContentType = _maintenancePage.ContentType;

                context.Request.Path = _maintenancePage.MaintenanceHandlerPath;
            }
            await _next.Invoke(context);
        }
    }
}
