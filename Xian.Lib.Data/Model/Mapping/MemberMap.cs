using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Xian.Lib.Data.Model.Mapping
{
    public class MemberMap : EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            ToTable("Member");
        }
    }
}