namespace MemeBot
{
    using System;
    using System.IO;

    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        private static void Main(string[] args) => Program.BuildWebHost(args, new ConfigurationBuilder().AddCommandLine(args).Build()).Run();

        /// <summary>
        /// Builds the web host.
        /// </summary>
        private static IWebHost BuildWebHost(string[] args, IConfiguration config) => WebHost.CreateDefaultBuilder(args).UseKestrel().UseContentRoot(Directory.GetCurrentDirectory()).UseConfiguration(config).UseIISIntegration().UseStartup<Loader>().UseUrls($"http://*:{Environment.GetEnvironmentVariable("PORT")}/").Build();
    }
}
