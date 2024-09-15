using FirstMicroservice.Todos.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMicroservice.Todos.WebAPI.Context
{
    public sealed class AppDbContext : DbContext //sealed anahtar kelimesi, bir sınıfın kalıtılmasını (inheritance) engellemek için kullanılır.
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ToDo> ToDos { get; set; }

        
    }
}
