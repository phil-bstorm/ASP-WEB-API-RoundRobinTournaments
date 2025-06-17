using RoundRobinTournaments.Domain.CustomEnums;

namespace RoundRobinTournaments.Domain.Models
{
	public class Utilisateur
	{
		public int Id { get; set; }
		public required string Username { get; set; }
		public required string Email { get; set; }
		public required string Password { get; set; }
		public int Elo { get; set; } = 1200; // Default Elo rating
		public DateOnly BirhDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
		public UtilisateurRole Role { get; set; } = UtilisateurRole.Player; // Default role
		public string? AvatarUrl { get; set; }

		// Navigation properties
		public List<InscriptionPlayerTournament> InscriptionPlayerTournaments { get; set; } = [];
		public List<GameRoundPlayerTournament> WhiteMatches { get; set; } = [];
		public List<GameRoundPlayerTournament> BlackMatches { get; set; } = [];
	}
}
