namespace Xian.Lib.Data.Model
{
    /// <summary>
    /// 會員
    /// </summary>
    public class Member
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
    }
}