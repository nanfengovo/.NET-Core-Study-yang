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


        /// <summary>
        /// 测试是否有admin角色，没有则创建，是否有yzk用户，没有则创建，是否有yzk用户属于admin角色，没有则添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> Test1()
        {
            if (await roleManager.RoleExistsAsync("admin") == false)
            {
                MyRole Role = new MyRole { Name = "admin" };
                var result = await roleManager.CreateAsync(Role);
                if (!result.Succeeded)
                {
                    return BadRequest("roleManager.Create failed!!");
                }

            }
            MyUser user1 = await userManager.FindByNameAsync("yzk");
            if (user1 == null)
            {
                user1 = new MyUser { UserName = "yzk" };
                var result = await userManager.CreateAsync(user1, "123456");
                if (!result.Succeeded)
                {
                    return BadRequest("userManager.Create failed!!");
                }
            }
            if (!await userManager.IsInRoleAsync(user1, "admin"))
            {
                var result = userManager.AddToRoleAsync(user1, "admin");
                if (!result.Result.Succeeded)
                {
                    return BadRequest("userManager.AddToRoleAsync failed!!");
                }
            }
            return "ok!";
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CheckPwd(CheckPwdRequest req)
        {
            string userName = req.UserName;
            string pwd = req.Password;
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                if (webHostEnvironment.IsDevelopment())
                {
                    return BadRequest("用户名不存在！！");
                }
                else
                {
                    return BadRequest();
                }

            }
            if (await userManager.IsLockedOutAsync(user))
            {
                return BadRequest("用户已被锁定！");
            }
            if (await userManager.CheckPasswordAsync(user, pwd))
            {
                //登录成功后，重置登录失败次数
                await userManager.ResetAccessFailedCountAsync(user);
                return Ok("登录成功！");
            }
            else
            {
                //登录失败后，增加登录失败次数
                await userManager.AccessFailedAsync(user);
                return BadRequest("用户名或密码错误！！");
            }

        }


        /// <summary>
        /// 重置密码的验证码
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SendResetPasswordToken(string userName)

        {
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return BadRequest("用户名不存在！");
            }
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            Console.WriteLine($"验证码是{token}");
            //发送token到用户邮箱
            return Ok(token);
        }


        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> ResetPassword(string userName, string token, string newPassword)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return BadRequest("用户名不存在！");
            }
            var result = await userManager.ResetPasswordAsync(user, token, newPassword);
            if (result.Succeeded)
            {
                return Ok("重置密码成功！");
            }
            else
            {
                return BadRequest("重置密码失败！");
            }
        }

    }
}

