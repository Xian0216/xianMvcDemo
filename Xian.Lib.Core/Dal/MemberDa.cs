using System.Diagnostics;
using System.Linq;
using Xian.Lib.Data.Model;

namespace Xian.Lib.Core.Dal
{
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
            XianTestDbContext.Database.Log = (i) => Debug.WriteLine(i);
            XianTestDbContext.Members.Add(new Member()
            {
                Account = account,
                Password = encryptPassword
            });

            XianTestDbContext.SaveChanges();
        }
    }
}