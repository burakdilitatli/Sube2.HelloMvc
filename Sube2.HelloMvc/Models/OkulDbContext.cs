using Microsoft.EntityFrameworkCore;

namespace Sube2.HelloMvc.Models
{
    public class OkulDbContext:DbContext
    {
        public OkulDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Ogrenci> Ogrenciler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // Varsayılan olarak appsettings.json'dan gelen bağlantı dizesini kullanacağız
            // Bu metot sadece DbContext'in doğrudan oluşturulması durumunda çağrılır
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=TYWEX\MALACHITEGREEN;Initial Catalog=OkulDBMVCSube2;Integrated Security=true;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o=>o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(40).IsRequired();
        }
    }
}
