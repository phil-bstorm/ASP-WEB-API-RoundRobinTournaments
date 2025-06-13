using System.ComponentModel.DataAnnotations;

namespace RoundRobinTournaments.API.DTOs
{
	/* INPUT DTO */
	public class AuthRegisterDTO
	{
		[Required]
		public required string Username { get; set; }

		[Required]
		public required string Password { get; set; }

		[Required]
		public required string Email { get; set; }

		public int Elo { get; set; }

		[Required]
		public required DateOnly BirhDate { get; set; }
	}

	public class AuthLoginDTO
	{
		[Required]
		public required string Username { get; set; }

		[Required]
		public required string Password { get; set; }
	}

	/* OUTPUT DTO */
	public class TokenResponse
	{
		public required string Token { get; set; }
	}

}
