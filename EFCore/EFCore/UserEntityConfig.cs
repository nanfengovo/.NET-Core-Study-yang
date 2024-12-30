using EFCore.EntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore
{
    internal class UserEntityConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //表名 —— T_User
            builder.ToTable("T_User");

            //用户名是必填的最大长度是10位
            builder.Property(x=>x.UserName).HasMaxLength(10).IsRequired();

            //密码是必填的最大长度是20位
            builder.Property(x => x.Password).HasMaxLength(20).IsRequired();


        }
    }
}
