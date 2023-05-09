using Microsoft.EntityFrameworkCore;
using WorkWise.Model.Database.Tables;

namespace WorkWise.Database
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public StoreDbContext() { }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
            options.UseSqlServer("Server=tcp:workwiseserver.database.windows.net,1433;Initial Catalog=WorkWise_Database;Persist Security Info=False;User ID=workwise;Password=rT5665tyyt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Server=tcp:workwiseserver.database.windows.net,1433;Initial Catalog=WorkWise_Database;Persist Security Info=False;User ID=workwise;Password=rT5665tyyt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
            .Property(u => u.RegDate)
            .HasColumnType("date")
            .HasDefaultValueSql("GETDATE()");
        }

    }
}