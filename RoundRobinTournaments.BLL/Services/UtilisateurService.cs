using Isopoh.Cryptography.Argon2;
using RoundRobinTournaments.BLL.CustomExceptions;
using RoundRobinTournaments.BLL.Services.Interfaces;
using RoundRobinTournaments.DAL.Repositories.Interfaces;
using RoundRobinTournaments.Domain.Models;

namespace RoundRobinTournaments.BLL.Services
{
	public class UtilisateurService : IUtilisateurService
	{
		private readonly IUtilisateurRepository _utilisateurRepository;

		public UtilisateurService(IUtilisateurRepository utilisateurRepository)
		{
			_utilisateurRepository = utilisateurRepository;
		}

		public Utilisateur Create(Utilisateur entity)
		{
			Utilisateur? existingUser = _utilisateurRepository.GetByUsername(entity.Username);
			if (existingUser is not null)
			{
				throw new UsernameAlreadyUsedException();
			}

			existingUser = _utilisateurRepository.GetByEmail(entity.Email);
			if (existingUser is not null)
			{
				throw new EmailAlreadyUsedException();
			}

			// hash the password
			entity.Password = Argon2.Hash(entity.Password);

			return _utilisateurRepository.Create(entity);
		}

		public bool Delete(int id)
		{
			Utilisateur? utilisateur = _utilisateurRepository.GetById(id);
			if (utilisateur == null)
			{
				throw new NotFoundException();
			}
			return _utilisateurRepository.Delete(utilisateur);
		}

		public IEnumerable<Utilisateur> GetAll(int offset, int limit = 20)
		{
			return _utilisateurRepository.GetAll(offset, limit);
		}

		public Utilisateur GetById(int key)
		{
			Utilisateur? utilisateur = _utilisateurRepository.GetById(key);
			if (utilisateur == null)
			{
				throw new NotFoundException();
			}
			return utilisateur;
		}

		public IEnumerable<Utilisateur> GetByIds(List<int> keys)
		{
			return _utilisateurRepository.GetByIds(keys);
		}

		public Utilisateur GetByUsername(string username)
		{
			Utilisateur? utilisateur = _utilisateurRepository.GetByUsername(username);
			if (utilisateur == null)
			{
				throw new NotFoundException();
			}
			return utilisateur;
		}

		public Utilisateur GetByEmail(string email)
		{
			Utilisateur? utilisateur = _utilisateurRepository.GetByEmail(email);
			if (utilisateur == null)
			{
				throw new NotFoundException();
			}
			return utilisateur;
		}

		public Utilisateur Update(Utilisateur entity)
		{
			Utilisateur? utilisateur = _utilisateurRepository.GetById(entity.Id);
			if (utilisateur == null)
			{
				throw new NotFoundException();
			}

			return _utilisateurRepository.Update(entity);
		}

		public Utilisateur Login(string username, string password)
		{
			Utilisateur? utilisateur = _utilisateurRepository.GetByUsername(username);

			if (utilisateur is null || !Argon2.Verify(utilisateur.Password, password))
			{
				throw new InvalidLoginException();
			}

			return utilisateur;
		}
	}
}
