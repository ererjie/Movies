using EInfrastructure.Core.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domin;

namespace Movies.Respository.Mysql.Map
{
    public class MoviesGroupMap : IEntityMap<MoviesGroup>
    {
        public void Map(EntityTypeBuilder<MoviesGroup> builder)
        {
            builder.ToTable("movies_group");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.AccountId);
            builder.Property(x => x.Name);
            builder.Property(x => x.CreateTime);
            builder.Property(x => x.EditTime);
            builder.Property(x => x.IsDel);
            builder.Property(x => x.DelTime);
            builder.HasMany(x => x.MoviesTag).WithOne(x => x.MoviesGroup).HasForeignKey(x => x.MoviesGroupId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
