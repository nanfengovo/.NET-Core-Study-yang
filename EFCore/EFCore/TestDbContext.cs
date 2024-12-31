using EFCore.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    internal class TestDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStr = "Server = . ;Database = PLCHelper ;User=sa ;Password=aaaa2624434145 ;Encrypt=True;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(conStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }


    }
}
