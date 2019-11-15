using System;

namespace MaintenancePage.Infrastructure
{
    public class MaintenancePage
    {
        private readonly Func<bool> _enabledFunc;

        public MaintenancePage(Func<bool> enabledFunc, string response)
        {
            _enabledFunc = enabledFunc;
            MaintenanceHandlerPath = response;
        }

        public bool Enabled => _enabledFunc();
        public string MaintenanceHandlerPath { get; }

        public int RetryAfterInSeconds { get; set; } = 3600;
        public string ContentType { get; set; } = "text/html";
    }
}
