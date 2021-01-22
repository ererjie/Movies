using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domin.Model;

namespace Movies.Respository.Mysql.Map
{
    public class MoviesTagMap : IEntityMap<MoviesTag>
    {
        public void Map(EntityTypeBuilder<MoviesTag> builder)
        {
            builder.ToTable("movies_tag");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.MoviesGroupId);
            builder.Property(x => x.CreateTime);
        }

    }
}
