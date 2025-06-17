using Checkmate.Domain.Models;

namespace Checkmate.DAL.Repositories.Interfaces
{
	public interface IUtilisateurRepository : IRepository<int, Utilisateur>
	{
		public Utilisateur? GetByUsername(string username);
		public Utilisateur? GetByEmail(string email);
	}
}
