using FiapSmartCity.Models;
using Microsoft.EntityFrameworkCore;

namespace FiapSmartCity.Repository.Context
{
    // Context faz relação com o banco de dados e o DbSet faz relação com as tabelas
    public class DataBaseContext : DbContext
    {
        public DbSet<ProductTypeEF> ProductTypeEF { get; set; }
        public DbSet<ProductEF> ProductEF { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("FiapSmartCityConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}