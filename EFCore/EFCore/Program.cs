using EFCore.EntityModel;
using System;
using System.Linq;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var ctx = new TestDbContext())
            {
                #region 初始化数据 只能初始化一次  增
                //var user1 = new EntityModel.User { UserName = "admin", Password = "12345" };
                //ctx.Users.Add(user1);
                //ctx.SaveChanges();

                //var book1 = new EntityModel.Book { AuthorName = "张三", Title = "BOOK1", Price = 10 };
                //var book2 = new EntityModel.Book { AuthorName = "李四", Title = "BOOK2", Price = 20 };
                //var book3 = new EntityModel.Book { AuthorName = "张三", Title = "BOOK3", Price = 30 };
                //var book4 = new EntityModel.Book { AuthorName = "王五", Title = "BOOK4", Price = 40 };
                //var book5 = new EntityModel.Book { AuthorName = "张三", Title = "BOOK5", Price = 50 };
                //var book6 = new EntityModel.Book { AuthorName = "王五", Title = "BOOK6", Price = 60 };
                //ctx.Books.AddRange(book1, book2, book3, book4, book5, book6);
                //ctx.SaveChanges();
                //Console.WriteLine("初始化数据成功！");
                #endregion
                #region 查
                //var books = ctx.Books.Where(x => x.Price > 30);
                //foreach (var b in books)
                //{
                //    Console.WriteLine(b.Title);
                //}
                #endregion

                #region 删
                #region 重置脏数据的代码
                //var books = ctx.Books.Where(x => x.Price > 0);
                //foreach(var b in books)
                //{
                //    ctx.Remove(b);
                //}

                //ctx.SaveChanges();
                //Console.WriteLine("数据重置成功！");
                #endregion

                #region 删除价格为40的第一本书 --查到第一个后删除
                //try
                //{
                //    var book = ctx.Books.Where(x => x.Price == 40).FirstOrDefault();
                //    ctx.Remove(book);
                //    ctx.SaveChanges();
                //    Console.WriteLine("删除成功！");
                //}
                //catch (Exception)
                //{

                //    Console.WriteLine("不存在价格为40的书！");
                //}

                #endregion


                #endregion


                #region 改   查到后修改
                //将价格为50的书的价格改为100
                var book = ctx.Books.Where(x => x.Price == 50).FirstOrDefault();
                if (book != null)
                {
                    book.Price = 100;
                    ctx.SaveChanges();
                    Console.WriteLine("修改成功！");
                }
                else
                {
                    Console.WriteLine("不存在价格为50的书！");
                }


                #endregion
            }




        }
    }
}