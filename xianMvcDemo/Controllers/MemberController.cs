using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Xian.Lib.Core.Logic;
using Xian.Lib.Data;
using xianMvcDemo.Models;

namespace xianMvcDemo.Controllers
{
    public class MemberController : Controller
    {
        private readonly MemberLogic _memberLogic;

        public MemberController()
        {
            _memberLogic = new MemberLogic();
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Register(string account, string password)
        {
            var loginResult = _memberLogic.Register(account, password);
            return Json(loginResult);
        }

        /// <summary>
        /// 登入
        /// </summary>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Login(LoginViewModel loginViewModel)
        {
            var loginResult = _memberLogic.Login(loginViewModel.Account, loginViewModel.Password);
            if (loginResult.IsSuccess)
            {
                var ticket = new FormsAuthenticationTicket(
                    version: 1,
                    name: loginResult.ReturnObject.MemberId.ToString(), //可以放使用者Id
                    issueDate: DateTime.UtcNow, //現在UTC時間
                    expiration: DateTime.UtcNow.AddMinutes(30), //Cookie有效時間=現在時間往後+30分鐘
                    isPersistent: true, // 是否要記住我 true or false
                    userData: "Member", //可以放使用者角色名稱
                    cookiePath: FormsAuthentication.FormsCookiePath);

                var encryptedTicket = FormsAuthentication.Encrypt(ticket); //把驗證的表單加密
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(cookie);
            }

            return Json(loginResult);
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Member");
        }

    }
}