using RoundRobinTournaments.API.DTOs;
using RoundRobinTournaments.Domain.CustomEnums;
using RoundRobinTournaments.Domain.Models;

namespace RoundRobinTournaments.API.Mappers
{
	public static class UtilisateurMappers
	{
		public static Utilisateur ToUtilisateur(this UtilisateurUpdateDTO dto) {
			return new Utilisateur { 
				Email = dto.Email,
				Username = dto.Username,
				Elo = dto.Elo,
				BirhDate = dto.birhtDate,
				Password = "" // can't be changed from Update route
			};
		}

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

		public static UtilisateurDTO ToUtilisateurDTO(this Utilisateur utilisateur)
		{
			IEnumerable<UtilisateurGameRoundPlayerTournamentDTO> games = utilisateur.BlackMatches.Select(x => new UtilisateurGameRoundPlayerTournamentDTO
			{
				TournamentId = x.Tournament.Id,
				TournamentName = x.Tournament.Name,
				Color = x.Black.Id == utilisateur.Id ? UtilisateurColor.Black : UtilisateurColor.White,
				CurrentElo = x.Black.Id == utilisateur.Id ? x.BlackElo : x.WhiteElo,
				Opponent = x.Black.Id == utilisateur.Id ? x.White.ToUtilisateurListDTO() : x.Black.ToUtilisateurListDTO(),
				OpponentElo = x.Black.Id == utilisateur.Id ? x.WhiteElo : x.BlackElo,
				Round = x.Round,
				Result = x.Result,
			});

			return new UtilisateurDTO
			{
				Id = utilisateur.Id,
				Username = utilisateur.Username,
				Email = utilisateur.Email,
				Elo = utilisateur.Elo,
				BirhtDate = utilisateur.BirhDate,
				Role = utilisateur.Role.ToString(),
				Insccriptions = utilisateur.InscriptionPlayerTournaments.Select(i => new UtilisateurInscriptionPlayerTournamentDTO
				{
					TournamentId = i.Tournament.Id,
					TournamentName = i.Tournament.Name,
					InscriptionDate = i.InscriptionDate,
					CanceledAt = i.CanceledAt
				}).ToList(),
				Games = games.ToList(),
			};
		}
	}
}
