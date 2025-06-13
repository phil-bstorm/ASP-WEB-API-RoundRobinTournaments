namespace RoundRobinTournaments.API.DTOs
{
	public class UtilisateurListDTO
	{
		public required int Id { get; set; }
		public required string Username { get; set; }
		public required string Email { get; set; }
		public required int Elo { get; set; }
		public required DateOnly BirhtDate { get; set; }
		public required string Role { get; set; }
	}
}
