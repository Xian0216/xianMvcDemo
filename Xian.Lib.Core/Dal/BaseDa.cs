using System.Configuration;
using Xian.Lib.Data;

namespace Xian.Lib.Core.Dal
{
    public class BaseDa
    {
        private static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["XianTestDbContext"].ConnectionString;

        public XianTestDbContext XianTestDbContext = new XianTestDbContext(ConnectionString);
    }
}