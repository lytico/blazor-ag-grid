using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Example1.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder
                    //.UseUrls("https://*:5001")
                    //.UseKestrel()
                    //.UseConfiguration(new ConfigurationBuilder()
                    //    .AddCommandLine(args)
                    //    .Build())
                    .UseStartup<Startup>());
    }

}
