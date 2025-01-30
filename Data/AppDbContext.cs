using API._1.Data;
using API._1.Models;
using Microsoft.EntityFrameworkCore;

namespace API._1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

