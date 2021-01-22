using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domin.Model;

namespace Movies.Respository.Mysql.Map
{
    /// <summary>
    /// 轮播
    /// </summary>
    public class MoviesBannerMap : IEntityMap<MoviesBanner>
    {
        public void Map(EntityTypeBuilder<MoviesBanner> builder)
        {
            builder.ToTable("movies_banner");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Banner);
            builder.Property(x => x.Introduction);
            builder.Property(x => x.MoviesId);
        }
    }
}
