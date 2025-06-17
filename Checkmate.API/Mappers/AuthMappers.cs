using Checkmate.API.DTOs;
using Checkmate.Domain.Models;

namespace Checkmate.API.Mappers
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
				Birthdate = dto.BirthDate
			};
		}
	}
}
