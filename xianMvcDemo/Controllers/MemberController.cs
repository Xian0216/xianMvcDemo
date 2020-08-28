using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using NLog;
using Xian.Lib.Core.Dto;
using Xian.Lib.Core.Extension;
using Xian.Lib.Core.Utility;
using Xian.Lib.Data;
using Xian.Lib.Data.Model;
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
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register(string account, string password)
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
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            var loginResult = _memberLogic.Login(loginViewModel.Account, loginViewModel.Password);
            return Json(loginResult);
        }
    }


    /// <summary>
    /// 會員邏輯
    /// </summary>
    public class MemberLogic
    {
        private readonly ILogger _logger;
        private readonly MemberDa _memberDa;

        /// <summary>
        /// 建構式
        /// </summary>
        public MemberLogic()
        {
            _logger = LoggerUtility.GetLogger();
            _memberDa = new MemberDa();
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IsSuccessResult<bool> Login(string account, string password) 
        {
            try
            {
                var member = _memberDa.GetMemberByAccount(account);
                if (member == null)
                {
                    return new IsSuccessResult<bool>("此帳號不存在！");
                }

                var encryptPassword = password.ToMd5();

                return member.Password == encryptPassword ?
                    new IsSuccessResult<bool>() :
                    new IsSuccessResult<bool>("密碼錯誤！");
            }
            catch (Exception ex)
            {
                _logger.Error($"登入發生錯誤 : {ex}");
                return new IsSuccessResult<bool>("登入發生異常錯誤");
            }
        }

        /// <summary>
        /// 註冊
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IsSuccessResult<bool> Register(string account, string password)
        {
            try
            {
                var member = _memberDa.GetMemberByAccount(account);
                if (member != null)
                {
                    _logger.Warn($"此帳號嘗試登入 : {account}");
                    return new IsSuccessResult<bool>("此帳號已存在！");
                }

                _memberDa.CreateMember(account, password.ToMd5());

                return new IsSuccessResult<bool>();
            }
            catch (Exception ex)
            {
                _logger.Error($"登入發生錯誤 : {ex}");
                return new IsSuccessResult<bool>("登入發生異常錯誤");
            }
        }
    }

    public class BaseDa
    {
        private string _connectionString =>
            ConfigurationManager.ConnectionStrings["XianTestDbContext"].ConnectionString;

        public XianTestDbContext XianTestDbContext => new XianTestDbContext(_connectionString);
    }

    /// <summary>
    /// 會員　DAL 層
    /// </summary>
    public class MemberDa : BaseDa
    {
        public Member GetMemberByAccount(string account)
        {
            return XianTestDbContext.Members.FirstOrDefault(r => r.Account == account);
        }

        public void CreateMember(string account, string encryptPassword)
        {
            XianTestDbContext.Members.Add(new Member()
            {
                Account = account,
                Password = encryptPassword
            });

            XianTestDbContext.SaveChanges();
        }
    }
}