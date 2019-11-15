using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenancePage.Infrastructure
{
    public class MaintenancePage
    {
        private readonly Func<bool> _enabledFunc;
        private readonly byte[] _response;

        public MaintenancePage(Func<bool> enabledFunc, byte[] response)
        {
            _enabledFunc = enabledFunc;
            _response = response;
        }

        public bool Enabled => _enabledFunc();
        public byte[] Response => _response;

        public int RetryAfterInSeconds { get; set; } = 3600;
        public string ContentType { get; set; } = "text/html";
    }
}
