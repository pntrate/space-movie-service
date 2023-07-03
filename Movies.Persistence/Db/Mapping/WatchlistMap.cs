using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Entities;

namespace Movies.Persistence.Db.Mapping
{
	public class WatchlistMap : DbEntityConfiguration<Watchlist>
	{
		public override void Configure(EntityTypeBuilder<Watchlist> entity)
		{
			entity.ToTable("Watchlist");

			entity.HasKey(e => e.Id);

			entity.Property(e => e.UserId)
				  .HasColumnName("UserId")
				  .IsRequired();

			entity.Property(e => e.LastUpdateDate)
				  .HasColumnName("LastUpdateDate")
				  .IsRequired();

			entity.HasMany(e => e.Movies)
				  .WithOne()
				  .HasForeignKey(e => e.WatchlistId);
		}
	}
}