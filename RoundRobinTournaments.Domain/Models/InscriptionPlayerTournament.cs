namespace RoundRobinTournaments.Domain.Models
{
	public class InscriptionPlayerTournament
	{
		public Utilisateur Player { get; set; }
		public Tournament Tournament { get; set; }
		public DateTime InscriptionDate { get; set; } = DateTime.Now;
		public DateTime? Canceled_at { get; set; } = null;
	}
}
