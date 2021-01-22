using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domin.Model;

namespace Movies.Respository.Mysql.Map
{
    public class MoviesIntroductionMap : IEntityMap<MoviesIntroduction>
    {
        public void Map(EntityTypeBuilder<MoviesIntroduction> builder)
        {
            builder.ToTable("movies_introduction");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.DirectorName);
            builder.Property(x => x.ActorName);
            builder.Property(x => x.IntroductionContent);
            builder.Property(x => x.CreateTime);
            builder.Property(x => x.UpdateTime);
        }
    }
}
