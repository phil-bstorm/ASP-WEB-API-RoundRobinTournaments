using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoundRobinTournaments.Domain.Models;

namespace RoundRobinTournaments.DAL.Database.Configurations
{
	public class GameRoundPlayerTournamentConfig : IEntityTypeConfiguration<GameRoundPlayerTournament>
	{
		public void Configure(EntityTypeBuilder<GameRoundPlayerTournament> builder)
		{
			builder.ToTable("GameRoundPlayerTournaments");

			// COLUMNS
			builder.Property(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder.Property(x => x.Round)
				.HasColumnName("round")
				.IsRequired();

			builder.Property(x => x.Result)
				.HasColumnName("result")
				.HasConversion<string>() // Assuming GameRoundResult is an enum
				.IsRequired(false);

			// CONSTRAINTS
			builder.HasKey(x => x.Id);

			// RELATIONSHIPS
			builder.HasOne(x => x.Tournament)
				.WithMany(t => t.Rounds)
				.HasForeignKey("tournament_id")
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(x => x.White)
				.WithMany(u => u.WhiteMatches)
				.HasForeignKey("white_id")
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.Black)
				.WithMany(u => u.BlackMatches)
				.HasForeignKey("black_id")
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
