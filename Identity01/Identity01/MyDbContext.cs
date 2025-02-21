using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity01
{
    public class MyDbContext:IdentityDbContext<MyUser,MyRole,long>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
    : base(options)
        {

        }
    }
}
