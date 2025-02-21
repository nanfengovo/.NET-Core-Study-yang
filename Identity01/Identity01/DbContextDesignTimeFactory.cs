using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity01
{
    public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.UseSqlServer("Server = . ;Database = Identity ;User=sa ;Password=aaaa2624434145 ;Encrypt=True;Trusted_Connection=True;TrustServerCertificate=True;");
            return new MyDbContext(builder.Options);
        }
    }
}
