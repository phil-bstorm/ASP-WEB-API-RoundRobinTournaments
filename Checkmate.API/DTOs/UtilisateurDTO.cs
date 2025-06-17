using Checkmate.Domain.CustomEnums;
using System.ComponentModel.DataAnnotations;

namespace Checkmate.API.DTOs
{
	public class UtilisateurUpdateDTO
	{
		[Required]
		public required string Username { get; set; }

		[Required]
		public required string Email { get; set; }

		[Required]
		public int Elo { get; set; }

		[Required]
		public required DateOnly birhtDate { get; set; }
	}

	public class UpdatePasswordDTO
	{
		[Required]
		[MinLength(3)]
		public required string Password { get; set; }
	}

	public class UpdateAvatarDTO
	{
		public IFormFile Image { get; set; } = null;
	}

	public class UtilisateurListDTO
	{
		public required int Id { get; set; }
		public required string Username { get; set; }
		public required string Email { get; set; }
		public required int Elo { get; set; }
		public required DateOnly BirhtDate { get; set; }
		public required string Role { get; set; }
	}

	public class UtilisateurInscriptionPlayerTournamentDTO
	{
		public required int TournamentId { get; set; }
		public required string TournamentName { get; set; }
		public required DateTime InscriptionDate { get; set; }
		public DateTime? CanceledAt { get; set; } = null;
	}

	public class UtilisateurGameRoundPlayerTournamentDTO
	{
		public required int TournamentId { get; set; }
		public required string TournamentName { get; set; }
		public required UtilisateurColor Color { get; set; }
		public required int CurrentElo { get; set; }
		public required UtilisateurListDTO Opponent { get; set; }
		public required int OpponentElo { get; set; }
		public required int Round { get; set; }
		public required GameRoundResult? Result { get; set; }
	}

	public class UtilisateurDTO
	{
		public required int Id { get; set; }
		public required string Username { get; set; }
		public required string Email { get; set; }
		public required int Elo { get; set; }
		public required DateOnly BirhtDate { get; set; }
		public required string Role { get; set; }
		public List<UtilisateurInscriptionPlayerTournamentDTO> Insccriptions { get; set; } = [];
		public List<UtilisateurGameRoundPlayerTournamentDTO> Games { get; set; } = [];
	}
}