using RoundRobinTournaments.Domain.CustomEnums;

namespace RoundRobinTournaments.Domain.Models
{
	public class Tournament
	{
		public int Id { get; set; }
		public Location Location { get; set; }
		public string Name { get; set; } = "";
		public int MinPlayers { get; set; } = 2;
		public int MaxPlayers { get; set; } = 32;
		public TournamentStatus Status { get; set; } = TournamentStatus.waiting; // Default status
		public DateTime EndInscriptionAt { get; set; } = DateTime.Now.AddDays(7); // Default to 7 days from now
		public DateTime StartAt { get; set; } = DateTime.Now.AddDays(14); // Default to 14 days from now
		public Gender? GenderRestriction { get; set; } = null;
		public string Description { get; set; } = "";
		public int CurrentRound { get; set; } = 0;

		// Navigation properties
		public List<InscriptionPlayerTournament> InscriptionPlayerTournaments { get; set; } = [];
		public List<GameRoundPlayerTournament> Rounds { get; set; } = [];
		public List<Category> Categories { get; set; } = [];
	}
}
