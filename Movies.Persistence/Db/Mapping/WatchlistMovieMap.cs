using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;

namespace Movies.Persistence.Db.Mapping
{
	public class WatchlistMovieMap : DbEntityConfiguration<WatchlistMovie>
	{
		public override void Configure(EntityTypeBuilder<WatchlistMovie> entity)
		{
			entity.ToTable("WatchlistMovie");

			entity.HasKey(e => e.Id);

			entity.Property(e => e.WatchlistId)
				  .HasColumnName("WatchlistId")
				  .IsRequired();

			entity.Property(e => e.ImdbMovieId)
				  .HasColumnName("ImdbMovieId")
				  .IsRequired();

			entity.Property(e => e.Image)
				  .HasColumnName("Image");

			entity.Property(e => e.MovieTitle) 
				  .HasColumnName("MovieTitle")
				  .IsRequired();

			entity.Property(e => e.Description)
				  .HasColumnName("Description");

			entity.Property(e => e.IsWatched)
				  .HasColumnName("IsWatched")
				  .IsRequired();

			entity.Property(e => e.WatchDate)
				  .HasColumnName("WatchDate");

			entity.Property(e => e.CreateDate)
				  .HasColumnName("CreateDate")
				  .IsRequired();
		}
	}
}
