using RoundRobinTournaments.API.DTOs;
using RoundRobinTournaments.Domain.Models;

namespace RoundRobinTournaments.API.Mappers
{
	public static class UtilisateurMappers
	{
		public static UtilisateurListDTO ToUtilisateurListDTO(this Utilisateur utilisateur)
		{
			return new UtilisateurListDTO
			{
				Id = utilisateur.Id,
				Username = utilisateur.Username,
				Email = utilisateur.Email,
				Elo = utilisateur.Elo,
				Role = utilisateur.Role.ToString(),
				BirhtDate = utilisateur.BirhDate
			};
		}
	}
}
