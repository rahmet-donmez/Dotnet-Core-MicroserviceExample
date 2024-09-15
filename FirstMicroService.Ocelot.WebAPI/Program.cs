using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace FirstMicroService.Ocelot.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            builder.Configuration.AddJsonFile("ocelot.json");//yeni eklediðimiz json ý tanýttýk
            builder.Services.AddOcelot();

            app.MapGet("/", () => "Hello World!");
            app.UseOcelot().Wait();//asenkron old için wait ile kullanýldý
            app.Run();
        }
    }
}
