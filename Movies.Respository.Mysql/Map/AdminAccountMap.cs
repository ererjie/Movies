using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domin;

namespace Movies.Respository.Mysql.Map
{
    public class AdminAccountMap : IEntityMap<AdminAccount>
    {
        public void Map(EntityTypeBuilder<AdminAccount> builder)
        {
            builder.ToTable("admin_account");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Account);
            builder.Property(x => x.Phone);
            builder.Property(x => x.NickName);
            builder.Property(x => x.Password);
            builder.Property(x => x.CreateTime);
            builder.Property(x => x.EditTime);
            builder.Property(x => x.LastLoginTime);
            builder.Property(x => x.IsDel);
            builder.Property(x => x.DelTime);
        }
    }
}
