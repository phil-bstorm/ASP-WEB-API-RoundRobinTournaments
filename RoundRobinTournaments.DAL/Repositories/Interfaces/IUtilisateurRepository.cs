using RoundRobinTournaments.Domain.Models;

namespace RoundRobinTournaments.DAL.Repositories.Interfaces
{
	public interface IUtilisateurRepository : IRepository<int, Utilisateur>
	{
		public Utilisateur? GetByUsername(string username);
		public Utilisateur? GetByEmail(string email);
	}
}
