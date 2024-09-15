using FirstMicroService.Categories.WebAPI.Context;
using FirstMicroService.Categories.WebAPI.Dtos;
using FirstMicroService.Categories.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMicroService.Categories.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));


                }
            );
            var app = builder.Build();

            app.MapGet("/categories/getall", async (AppDbContext context, CancellationToken cancellationToken) =>
            {
                var categories = await context.Categories.ToListAsync(cancellationToken);

                return categories;
            });

            app.MapPost("/categories/create", async (CreateCategoryDto request, AppDbContext context, CancellationToken cancellationToken) =>
            {
                bool isNameExists = await context.Categories.AnyAsync(p => p.Name == request.Name, cancellationToken);

                if (isNameExists)
                {
                    return Results.BadRequest(new { Message = "Girilen kategori ismiyle eþleþen veri bulunmaktadýr" });
                }

                Category category = new()
                {
                    Name = request.Name,
                };

                await context.Categories.AddAsync(category, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);

                return Results.Ok(new { Message = "Kategori oluþturma iþlemi baþarýlý" });
            });
            app.Run();
        }
    }
}
