using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoundRobinTournaments.Domain.Models;

namespace RoundRobinTournaments.DAL.Database.Configurations
{
	public class LocationConfig : IEntityTypeConfiguration<Location>
	{
		public void Configure(EntityTypeBuilder<Location> builder)
		{
			builder.ToTable("Location");

			// COLUMNS
			builder.Property(l => l.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder.Property(l => l.Name)
				.HasColumnName("name")
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(l => l.Address)
				.HasColumnName("address")
				.IsRequired()
				.HasMaxLength(200);

			builder.Property(l => l.City)
				.HasColumnName("city")
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(l => l.PostalCode)
				.HasColumnName("postal_code")
				.IsRequired()
				.HasMaxLength(20);

			builder.Property(l => l.Country)
				.HasColumnName("country")
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(l => l.Description)
				.HasColumnName("description")
				.IsRequired()
				.HasMaxLength(500);

			// CONSTRAINTS
			builder.HasKey(x => x.Id);

			// RELATIONSHIPS
			// relation with Tournament is defined in TournamentConfig
		}
	}
}
