using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Models
{
    public class AdtekDBContext : DbContext
    {
        public AdtekDBContext() { }

        public AdtekDBContext(DbContextOptions<AdtekDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            var connectionString = "Data Source=LOCALHOST; Initial Catalog=AdtekDB; User ID=adtek; Password=Passw0rd; TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;

        public DbSet<Usuario> Usuarios { get; set; } = null!;

        public DbSet<Contenido> Contenidos { get; set; } = null!;

    }
}
