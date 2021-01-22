using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Movies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        //public static void Main(string[] args)
        //{
        //    //System.AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
        //    //{
        //    //    Utils.GetLogService().Error("Fatal,未捕获的异常", e.ExceptionObject.ToString());
        //    //};
        //    //TaskScheduler.UnobservedTaskException += (_, ev) => { Utils.GetLogService().Error("Fatal,未捕获的异常", ev.Exception); };
        //    CreateWebHostBuilder(args).Build().Run();
        //}

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseKestrel()
        //        .ConfigureServices(services => services.AddAutofac())
        //        .UseUrls("http://*:5002")
        //        .UseStartup<Startup>()
        //        .UseIISIntegration();
    }
}
