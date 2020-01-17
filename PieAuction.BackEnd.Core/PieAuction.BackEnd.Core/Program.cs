using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using PieAuction.BackEnd.Core.DataGeneration;

namespace PieAuction.BackEnd.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Start Data Generator
            var dataGenerator = new DataGenerator();
            dataGenerator.StartGenerating();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
