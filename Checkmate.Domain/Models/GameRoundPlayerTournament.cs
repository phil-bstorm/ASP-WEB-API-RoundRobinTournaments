using Checkmate.Domain.CustomEnums;

namespace Checkmate.Domain.Models
{
	public class GameRoundPlayerTournament
	{
		public int Id { get; set; }
		public Tournament Tournament { get; set; }
		public Utilisateur White { get; set; }
		public int WhiteElo {  get; set; }
		public Utilisateur Black { get; set; }
		public int BlackElo { get; set; }
		public int Round { get; set; }
		public GameRoundResult? Result { get; set; } = null;
	}
}
