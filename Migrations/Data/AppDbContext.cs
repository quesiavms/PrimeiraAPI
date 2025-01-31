using API._1.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API._1.Migrations.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

