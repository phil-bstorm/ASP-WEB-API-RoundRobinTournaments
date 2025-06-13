using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoundRobinTournaments.API.DTOs;
using RoundRobinTournaments.API.Mappers;
using RoundRobinTournaments.BLL.Services.Interfaces;
using RoundRobinTournaments.Domain.CustomEnums;
using RoundRobinTournaments.Domain.Models;

namespace RoundRobinTournaments.API.Controllers
{
	[ApiController]
	[Route("User")]
	[Authorize]
	public class UtilisateurController : ControllerBase
	{
		private readonly IUtilisateurService _utilisateurService;

		public UtilisateurController(IUtilisateurService utilisateurService)
		{
			_utilisateurService = utilisateurService;
		}

		[HttpGet(Name = "Get all")]
		[Authorize(Roles = nameof(UtilisateurRole.Admin))]
		public ActionResult<List<UtilisateurListDTO>> GetAll([FromQuery] int offset = 0, [FromQuery] int limit = 20)
		{
			List<Utilisateur> utilisateurs = _utilisateurService.GetAll(offset, limit).ToList();

			List<UtilisateurListDTO> utilisateurDOTS = utilisateurs.Select(u => u.ToUtilisateurListDTO()).ToList();

			return Ok(utilisateurDOTS);
		}
	}
}
