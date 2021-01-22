using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domin.Model;

namespace Movies.Respository.Mysql.Map
{
    public class MoviesReleaseTimeMap : IEntityMap<MoviesReleaseTime>
    {
        public void Map(EntityTypeBuilder<MoviesReleaseTime> builder)
        {
            builder.ToTable("movies_release_time");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.ReleaseYear);
            builder.Property(x => x.CreateTime);
        }
    }
}
