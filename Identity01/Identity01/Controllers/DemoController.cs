using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Hosting.Internal;

namespace Identity01.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly UserManager<MyUser> userManager;

        private readonly RoleManager<MyRole> roleManager;

        private readonly IWebHostEnvironment webHostEnvironment;
        public DemoController(UserManager<MyUser> userManager, RoleManager<MyRole> roleManager, IWebHostEnvironment webHostEnvironment)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Test1()
        {
           if(await roleManager.RoleExistsAsync("admin")==false)
            {
                MyRole Role = new MyRole { Name = "admin"};
                var result = await roleManager.CreateAsync(Role);
                if(!result.Succeeded)
                {
                    return BadRequest("roleManager.Create failed!!");
                }

            }
            MyUser user1 = await userManager.FindByNameAsync("yzk");
            if(user1 == null)
            {
                user1 = new MyUser { UserName = "yzk" };
                var result = await userManager.CreateAsync(user1, "123456");
                if (!result.Succeeded)
                {
                    return BadRequest("userManager.Create failed!!");
                }
            }
            if(!await userManager.IsInRoleAsync(user1, "admin"))
            {
                var result = userManager.AddToRoleAsync(user1, "admin");
                if (!result.Result.Succeeded)
                {
                    return BadRequest("userManager.AddToRoleAsync failed!!");
                }
            }
            return "ok!";
        }


        [HttpPost]
        public async Task<ActionResult> CheckPwd(CheckPwdRequest req)
        {
            string userName = req.UserName;
            string pwd = req.Password;
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                if(webHostEnvironment.IsDevelopment())
                {
                    return BadRequest("用户名不存在！！");
                }
                else
                {
                    return BadRequest();
                }
               
            }
            if(! await userManager.IsLockedOutAsync(user))
            {
                return BadRequest("用户已被锁定！");
            }
            if (await userManager.CheckPasswordAsync(user,pwd))
            {
                return Ok("登录成功！");
            }
            else
            {
                return BadRequest("用户名或密码错误！！");
            }
            
        }
    }
}
