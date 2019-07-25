using ECommerce.Models;
using Microsoft.EntityFrameworkCore;


namespace ECommerce
{
    public class ECommerceContext:DbContext
    {
        public ECommerceContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            // DB Bağlantısı vb database instance'ını ilgilendiren ince ayarlar
            dbContextOptionsBuilder.UseSqlServer("Server=127.0.0.1;Database=ECommerce;User Id=sa;Password = 123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Database şeması uygulanırken kullanılacak kural setleri

            //modelBuilder.Entity<User>().Property(a => a.EMail).IsRequired();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
