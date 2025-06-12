using RoundRobinTournaments.Domain.CustomEnums;

namespace RoundRobinTournaments.Domain.Models
{
	public class Utilisateur
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int Elo { get; set; } = 1200; // Default Elo rating
		public DateOnly BirhDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
		public UtilisateurRole Role { get; set; } = UtilisateurRole.Player; // Default role
	}
}
