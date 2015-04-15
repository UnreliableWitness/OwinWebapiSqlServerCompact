using System;
using Microsoft.Owin.Hosting;

namespace Hoebeke.WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = "http://localhost:5000/";

            using (WebApp.Start<Startup>(new StartOptions(baseUrl) { ServerFactory = "Microsoft.Owin.Host.HttpListener" }))
            {
                // Keep the server going until we're done
                Console.WriteLine("Press Any Key To Exit");
                Console.ReadKey();
            }
        
        }
    }
}
