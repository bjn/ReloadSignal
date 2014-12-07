using System;
using System.Net.Mime;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;

namespace ReloadSignal
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!string.IsNullOrWhiteSpace(args[1]))
            {
                Console.Out.Write("Need to specify at least the directory to watch, optional filter");
                Console.Out.Write("I.e. c:\\projects\\myproject\\wwwroot (*.html)");
                Environment.Exit(-1);
            }

            string filter = "*.*";
            if (!string.IsNullOrWhiteSpace(args[2]))
            {
                filter = args[2];
            }

            var watcher = new Watch(args[0], filter);
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            watcher.Changed += (sender, eventArgs) => context.Clients.All.reload(new string[0]);
            string url = "http://*:4000";

            using (WebApp.Start(url))
            using (watcher)
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
}
