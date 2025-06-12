using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoundRobinTournaments.Domain.Models;

namespace RoundRobinTournaments.DAL.Database.Configurations
{
	public class UtilisateurConfig : IEntityTypeConfiguration<Utilisateur>
	{
		public void Configure(EntityTypeBuilder<Utilisateur> builder)
		{
			builder.ToTable("Utilisateur");

			// COLUMNS
			builder.Property(u => u.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();
			builder.Property(u => u.Username)
				.HasColumnName("username")
				.IsRequired()
				.HasMaxLength(50);
			builder.Property(u => u.Email)
				.HasColumnName("email")
				.IsRequired()
				.HasMaxLength(200);
			builder.Property(u => u.Password)
				.HasColumnName("password")
				.IsRequired();
			builder.Property(u => u.Elo)
				.HasColumnName("elo")
				.IsRequired();
			builder.Property(u => u.BirhDate)
				.HasColumnName("birth_date")
				.IsRequired()
				.HasColumnType("date");
			builder.Property(u => u.Role)
				.HasColumnName("role")
				.IsRequired()
				.HasConversion<string>(); // Assuming UtilisateurRole is an enum

			// CONSTRAINTS
			builder.HasKey(u => u.Id);
			builder.HasIndex(u => u.Username)
				.IsUnique();
			builder.HasIndex(u => u.Email)
				.IsUnique();

			// RELATIONS

		}
	}
}
