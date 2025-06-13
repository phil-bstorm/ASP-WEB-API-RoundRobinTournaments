using RoundRobinTournaments.API.DTOs;
using RoundRobinTournaments.Domain.Models;

namespace RoundRobinTournaments.API.Mappers
{
	public static class AuthMappers
	{
		public static Utilisateur ToUtilisateur(this AuthRegisterDTO dto)
		{
			return new Utilisateur
			{
				Username = dto.Username,
				Email = dto.Email,
				Password = dto.Password,
				Elo = dto.Elo,
				BirhDate = dto.BirhDate
			};
		}
	}
}
