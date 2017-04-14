using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Owin.Hosting;
using Topshelf;

namespace MessageBroker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Starting web Server...");

            //// Specify the URI to use for the local host:
            //string baseUri = "http://localhost:8888";
            
            //using (WebApp.Start<Startup>(baseUri))
            //{
            //    Console.WriteLine("Server running at {0} - press Enter to quit. ", baseUri);
            //    Console.ReadLine();
            //}

            HostFactory.Run(x =>
            {
                x.Service<Webserver>(s =>
                {
                    s.ConstructUsing(name => new Webserver());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
            });
        }
    }
}
