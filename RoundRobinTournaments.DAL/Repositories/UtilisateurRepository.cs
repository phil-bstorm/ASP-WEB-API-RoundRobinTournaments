using Microsoft.EntityFrameworkCore;
using RoundRobinTournaments.DAL.Database;
using RoundRobinTournaments.DAL.Repositories.Interfaces;
using RoundRobinTournaments.Domain.Models;

namespace RoundRobinTournaments.DAL.Repositories
{
	public class UtilisateurRepository : IUtilisateurRepository
	{
		private readonly TournamentContext _context;

		public UtilisateurRepository(TournamentContext context)
		{
			_context = context;
		}

		public Utilisateur Create(Utilisateur entity)
		{
			Utilisateur utilisateur = _context.Utilisateurs.Add(entity).Entity;
			_context.SaveChanges();
			return utilisateur;
		}

		public bool Delete(Utilisateur entity)
		{
			bool isDeleted = _context.Utilisateurs.Remove(entity).State == EntityState.Deleted;
			_context.SaveChanges();
			return isDeleted;
		}

		public IEnumerable<Utilisateur> GetAll(int offset, int limit = 20)
		{
			return _context.Utilisateurs
				.Skip(offset)
				.Take(limit);
		}

		public Utilisateur? GetById(int key)
		{
			return _context.Utilisateurs
				.Include(u => u.InscriptionPlayerTournaments)
				.Include(u => u.WhiteMatches)
				.Include(u => u.BlackMatches)
				.FirstOrDefault(u => u.Id == key);
		}

		public IEnumerable<Utilisateur> GetByIds(List<int> keys)
		{
			return _context.Utilisateurs
				.Include(u => u.InscriptionPlayerTournaments)
				.Include(u => u.WhiteMatches)
				.Include(u => u.BlackMatches)
				.Where(u => keys.Contains(u.Id));
		}

		public Utilisateur? GetByUsername(string username)
		{
			return _context.Utilisateurs
				.Include(u => u.InscriptionPlayerTournaments)
				.Include(u => u.WhiteMatches)
				.Include(u => u.BlackMatches)
				.FirstOrDefault(u => u.Username == username);
		}
		public Utilisateur? GetByEmail(string email)
		{
			return _context.Utilisateurs
				.Include(u => u.InscriptionPlayerTournaments)
				.Include(u => u.WhiteMatches)
				.Include(u => u.BlackMatches)
				.FirstOrDefault(u => u.Email == email);
		}

		public Utilisateur Update(Utilisateur entity)
		{
			//_context.Utilisateurs.Update(entity); pas nécessaire car le "tracking" est activé
			_context.SaveChanges();
			return entity;
		}
	}
}
