using System;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var ctx = new TestDbContext())
            {
                var user1 = new EntityModel.User { UserName = "admin", Password = "12345" };
                ctx.Users.Add(user1);
                 ctx.SaveChanges();
                Console.WriteLine("初始化数据成功！");
            }
            
            
        }
    }
}