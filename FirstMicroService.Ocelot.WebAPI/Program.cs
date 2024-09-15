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

            builder.Configuration.AddJsonFile("ocelot.json");//yeni ekledi�imiz json � tan�tt�k
            builder.Services.AddOcelot();

            app.MapGet("/", () => "Hello World!");
            app.UseOcelot().Wait();//asenkron old i�in wait ile kullan�ld�
            app.Run();
        }
    }
}
