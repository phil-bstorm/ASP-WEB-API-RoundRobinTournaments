namespace Checkmate.Domain.Models
{
	public class InscriptionPlayerTournament
	{
		public int PlayerId { get; set; }
		public int TournamentId { get; set; }

		public Utilisateur Player { get; set; }
		public Tournament Tournament { get; set; }
		public DateTime InscriptionDate { get; set; } = DateTime.Now;
		public DateTime? CanceledAt { get; set; } = null;
	}
}
