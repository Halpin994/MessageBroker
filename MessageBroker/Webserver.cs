using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Owin.Hosting;

namespace MessageBroker
{
    public class Webserver
    {
        private IDisposable _webApp;

        public void Start()
        {
            _webApp = WebApp.Start<Startup>("http://localhost:8888");
        }
        public void Stop()
        {
            _webApp.Dispose();
        }
    }
}
