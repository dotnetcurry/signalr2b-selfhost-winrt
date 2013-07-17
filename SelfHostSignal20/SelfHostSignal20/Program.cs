using Microsoft.Owin.Hosting;
using System;

namespace SelfHostSignalR20
{
    class Program
    {
        static string url = "http://localhost:9999";

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
}
