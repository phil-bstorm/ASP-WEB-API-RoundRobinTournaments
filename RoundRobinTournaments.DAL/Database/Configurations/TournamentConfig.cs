using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoundRobinTournaments.Domain.Models;

namespace RoundRobinTournaments.DAL.Database.Configurations
{
	public class TournamentConfig : IEntityTypeConfiguration<Tournament>
	{
		public void Configure(EntityTypeBuilder<Tournament> builder)
		{
			builder.ToTable("Tournament");

			// COLUMNS
			builder.Property(t => t.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder.Property(t => t.Name)
				.HasColumnName("name")
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(t => t.MinPlayers)
				.HasColumnName("min_players")
				.IsRequired();

			builder.Property(t => t.MaxPlayers)
				.HasColumnName("max_players")
				.IsRequired();

			builder.Property(t => t.Status)
				.HasColumnName("status")
				.IsRequired()
				.HasConversion<string>(); // Assuming TournamentStatus is an enum

			builder.Property(t => t.EndInscriptionAt)
				.HasColumnName("end_inscription_at")
				.IsRequired()
				.HasColumnType("datetime");

			builder.Property(t => t.StartAt)
				.HasColumnName("start_at")
				.IsRequired()
				.HasColumnType("datetime");

			builder.Property(t => t.Description)
				.HasColumnName("description")
				.IsRequired()
				.HasMaxLength(500);

			builder.Property(t => t.CurrentRound)
				.HasColumnName("current_round")
				.IsRequired();

			// CONSTRAINTS
			builder.HasKey(t => t.Id);

			// RELATIONS
			// Tournament has one Location through a foreign key
			builder.HasOne(t => t.Location)
				.WithMany(l => l.Tournaments)
				.HasForeignKey("location_id") // Assuming location_id is a foreign key in Tournament
				.OnDelete(DeleteBehavior.Restrict);

			// Tournament has many Categories through a many-to-many relationship
			builder
				.HasMany(t => t.Categories)
				.WithMany(c => c.Tournaments)
				.UsingEntity(
					"MM_Tournament_Category",
					left =>
						left.HasOne(typeof(Category))
							.WithMany()
							.HasForeignKey("category_id")
							.HasPrincipalKey(nameof(Category.Id)),
					right =>
						right.HasOne(typeof(Tournament))
							.WithMany()
							.HasForeignKey("tournament_id")
							.HasPrincipalKey(nameof(Tournament.Id)),
					join => join.HasKey("tournament_id", "category_id")
				);
		}
	}
}
