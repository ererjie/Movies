using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domin.Model;

namespace Movies.Respository.Mysql.Map
{
    public class MoviesMap : IEntityMap<Domin.Movies>
    {
        public void Map(EntityTypeBuilder<Domin.Movies> builder)
        {
            builder.ToTable("movies");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Cover);
            builder.Property(x => x.CreateTime);
            builder.Property(x => x.UpdateTime);
            builder.Property(x => x.IsDel);
            builder.Property(x => x.DelTime);
            builder.Property(x => x.Douban);
            builder.Property(x => x.ReleaseYear);
            builder.Property(x => x.ReleaseMonth);
            builder.Property(x => x.ReleaseDay);
            builder.Property(x => x.ReleaseTime);
            builder.Property(x => x.AreaName);
            builder.Property(x => x.Sort);
            builder.Property(x => x.IsRecommend);
            builder.HasOne(x => x.MoviesAndGroup).WithOne(t => t.Movies).HasForeignKey<MoviesAndGroup>(t => t.Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.MoviesIntroduction).WithOne(t => t.Movies).HasForeignKey<MoviesIntroduction>(t => t.Id).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.MoviesDramaSeries).WithOne(x => x.Movies).HasForeignKey(x => x.MoviesId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.MoviesAndLine).WithOne(t => t.Movies).HasForeignKey<MoviesAndLine>(t => t.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
