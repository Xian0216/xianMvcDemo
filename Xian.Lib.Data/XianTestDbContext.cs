using System.Data.Entity;
using Xian.Lib.Data.Model;
using Xian.Lib.Data.Model.Mapping;

namespace Xian.Lib.Data
{
    public class XianTestDbContext : DbContext
    {
        public XianTestDbContext(string connectionString) 
            : base(connectionString)
        {
            
        }

        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new MemberMap());
        }
    }
}