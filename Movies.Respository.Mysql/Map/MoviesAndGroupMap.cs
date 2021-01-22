using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domin.Model;

namespace Movies.Respository.Mysql.Map
{
    /// <summary>
    /// 分组和影视信息关系表
    /// </summary>
    public class MoviesAndGroupMap : IEntityMap<MoviesAndGroup>
    {
        public void Map(EntityTypeBuilder<MoviesAndGroup> builder)
        {
            builder.ToTable("movies_and_group");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.MoviesGroupId);
            builder.Property(x => x.MoviesId);
            builder.Property(x => x.CreateTime);
        }

       
    }
}
