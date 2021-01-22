using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domin.Model;

namespace Movies.Respository.Mysql.Map
{
    public class MoviesLineMap : IEntityMap<MoviesLine>
    {
        public void Map(EntityTypeBuilder<MoviesLine> builder)
        {
            builder.ToTable("movies_line");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Url);
            builder.Property(x => x.MoviesRelatedId);
            builder.Property(x => x.CreateTime);
        }
    }
}
