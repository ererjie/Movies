using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domin.Model;

namespace Movies.Respository.Mysql.Map
{
    public class MoviesDramaSeriesMap : IEntityMap<MoviesDramaSeries>
    {
        public void Map(EntityTypeBuilder<MoviesDramaSeries> builder)
        {
            builder.ToTable("movies_drama_series");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.DramaSeriesNum);
            builder.Property(x => x.Url);
            builder.Property(x => x.MoviesId);
        }
    }
}
