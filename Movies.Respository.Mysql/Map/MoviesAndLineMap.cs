using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domin.Model;

namespace Movies.Respository.Mysql.Map
{
    public class MoviesAndLineMap : IEntityMap<MoviesAndLine>
    {
        public void Map(EntityTypeBuilder<MoviesAndLine> builder)
        {
            builder.ToTable("movies_and_line");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.MoviesId);
            builder.Property(x => x.MoviesLineId);
            builder.Property(x => x.CreateTime);
        }
    }
}
