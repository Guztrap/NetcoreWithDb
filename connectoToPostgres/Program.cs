namespace connectoToPostgres
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Steeltoe.Extensions.Configuration.CloudFoundry;
    using Steeltoe.Extensions.Configuration.PlaceholderCore;
    using Steeltoe.Common.Hosting;

    /// <summary>
    /// Class Program
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Method Main
        /// </summary>
        /// <param name="args">Array of arguments</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Method to create Web Host Builder
        /// </summary>
        /// <param name="args">Array of arguments</param>
        /// <returns>Object Web Host Builder</returns>
        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseCloudHosting(5102)            
                .AddCloudFoundry()
                .AddPlaceholderResolver()
                .UseStartup<Startup>();
    }
}
