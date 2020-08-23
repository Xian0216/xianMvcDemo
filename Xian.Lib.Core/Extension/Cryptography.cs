using System;
using System.Text;

namespace Xian.Lib.Core.Extension
{
    public static class Cryptography
    {
        public static string ToMd5(this string str)
        {
            using (var cryptoMd5 = System.Security.Cryptography.MD5.Create())
            {
                //將字串編碼成 UTF8 位元組陣列
                var bytes = Encoding.UTF8.GetBytes(str);

                //取得雜湊值位元組陣列
                var hash = cryptoMd5.ComputeHash(bytes);

                //取得 MD5
                var md5 = BitConverter.ToString(hash)
                    .Replace("-", string.Empty)
                    .ToUpper();

                return md5;
            }
        }
    }
}