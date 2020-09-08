using System;
using NLog;
using Xian.Lib.Core.Dal;
using Xian.Lib.Core.Dto;
using Xian.Lib.Core.Extension;
using Xian.Lib.Core.Utility;

namespace Xian.Lib.Core.Logic
{
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
        public IsSuccessResult<LoginInfo> Login(string account, string password)
        {
            try
            {
                var member = _memberDa.GetMemberByAccount(account);
                if (member == null)
                {
                    return new IsSuccessResult<LoginInfo>("This user is EXIST！");
                }

                var encryptPassword = password.ToMd5();

                return member.Password == encryptPassword ?
                    new IsSuccessResult<LoginInfo>()
                    {
                        ReturnObject = new LoginInfo() { MemberId = member.Id }
                    } :
                    new IsSuccessResult<LoginInfo>("Wrong Password！");
            }
            catch (Exception ex)
            {
                _logger.Error($"登入發生錯誤 : {ex}");
                return new IsSuccessResult<LoginInfo>("登入發生異常錯誤");
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
                    _logger.Warn($"此帳號嘗試註冊 : {account}");
                    return new IsSuccessResult<bool>("This user is EXIST！");
                }

                _memberDa.CreateMember(account, password.ToMd5());

                return new IsSuccessResult<bool>();
            }
            catch (Exception ex)
            {
                _logger.Error($"登入發生錯誤 : {ex}");
                return new IsSuccessResult<bool>("Register Throw Exception");
            }
        }
    }
}