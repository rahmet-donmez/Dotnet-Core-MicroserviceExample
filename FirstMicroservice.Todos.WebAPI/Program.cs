using FirstMicroservice.Todos.WebAPI.Context;
using FirstMicroservice.Todos.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMicroservice.Todos.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("MyDb");//bellek içi veri tabanýný kullanýr. uygulama çalýþýrken veriler tutulur tekrar baþlatýldýðýnda silinir
            });
            var app = builder.Build();

            app.MapPost("/todos/create", (string work, AppDbContext context) =>
            {
                ToDo todo = new()
                {
                    Work = work,
                };

                context.Add(todo);
                context.SaveChanges();

                return new { Message = "Ekleme iþlemi baþarýlý" };
            });


            app.MapGet("/todos/getall", (AppDbContext context) =>
            {
                var todos = context.ToDos.ToList();
                return todos;
            });
            app.Run();
        }
    }
}
