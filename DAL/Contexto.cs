using CryptoApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CryptoApi.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Coins> Coins { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coins>().HasData(
                new Coins { 
                    CoinId = 1,
                    Descripcion = "Bitcoin",
                    Valor = 20916.50,
                    ImagenUrl = "https://cdn.icon-icons.com/icons2/1487/PNG/512/8369-bitcoin_102502.png"
                }
               );

        }

    }
}
