using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoundRobinTournaments.Domain.Models;

namespace RoundRobinTournaments.DAL.Database.Configurations
{
	public class InscriptionPlayerTournamentConfig : IEntityTypeConfiguration<InscriptionPlayerTournament>
	{
		public void Configure(EntityTypeBuilder<InscriptionPlayerTournament> builder)
		{
			builder.ToTable("InscriptionPlayerTournaments");

			// COLUMNS
			builder.Property(i => i.PlayerId).HasColumnName("player_id");
			builder.Property(i => i.TournamentId).HasColumnName("tournament_id");

			builder.Property(i => i.InscriptionDate)
				.HasColumnName("inscription_date")
				.IsRequired()
				.HasColumnType("datetime");

			builder.Property(i => i.CanceledAt)
				.HasColumnName("canceled_at")
				.IsRequired(false)
				.HasColumnType("datetime");

			// CONSTRAINTS
			builder.HasKey(i => new { i.PlayerId, i.TournamentId, i.InscriptionDate })
				.HasName("PK_InscriptionPlayerTournaments");

			// RELATIONSHIPS
			builder.HasOne(i => i.Player)
				.WithMany(u => u.InscriptionPlayerTournaments)
				.HasForeignKey(i => i.PlayerId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_InscriptionPlayerTournaments_Utilisateur");

			builder.HasOne(i => i.Tournament)
				.WithMany(t => t.InscriptionPlayerTournaments)
				.HasForeignKey(i => i.TournamentId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_InscriptionPlayerTournaments_Tournament");

		}
	}
}
