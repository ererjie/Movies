using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domin.Model;

namespace Movies.Respository.Mysql.Map
{
    public class MoviesAreaMap : IEntityMap<MoviesArea>
    {
        public void Map(EntityTypeBuilder<MoviesArea> builder)
        {
            builder.ToTable("movies_area");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.AreaName);
            builder.Property(x => x.CreateTime);
        }
    }
}
