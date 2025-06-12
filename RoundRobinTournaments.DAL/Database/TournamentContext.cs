using Microsoft.EntityFrameworkCore;
using RoundRobinTournaments.DAL.Database.Configurations;
using RoundRobinTournaments.Domain.Models;

namespace RoundRobinTournaments.DAL.Database
{
	public class TournamentContext : DbContext
	{
		public TournamentContext(DbContextOptions<TournamentContext> options) : base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<Tournament> Tournaments { get; set; }
		public DbSet<Utilisateur> Utilisateurs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			/**
			 * DATA CONFIGURATIONS
			 */
			modelBuilder.ApplyConfiguration(new CategoryConfig());
			modelBuilder.ApplyConfiguration(new GameRoundPlayerTournamentConfig());
			modelBuilder.ApplyConfiguration(new InscriptionPlayerTournamentConfig());
			modelBuilder.ApplyConfiguration(new LocationConfig());
			modelBuilder.ApplyConfiguration(new TournamentConfig());
			modelBuilder.ApplyConfiguration(new UtilisateurConfig());
		}
	}
}
