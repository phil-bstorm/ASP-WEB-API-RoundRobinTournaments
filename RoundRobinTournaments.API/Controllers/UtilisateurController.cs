using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoundRobinTournaments.API.DTOs;
using RoundRobinTournaments.API.Mappers;
using RoundRobinTournaments.BLL.Services.Interfaces;
using RoundRobinTournaments.Domain.CustomEnums;
using RoundRobinTournaments.Domain.Models;
using System.Security.Claims;

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
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<List<UtilisateurListDTO>> GetAll([FromQuery] int offset = 0, [FromQuery] int limit = 20)
		{
			List<Utilisateur> utilisateurs = _utilisateurService.GetAll(offset, limit).ToList();

			List<UtilisateurListDTO> utilisateurDOTS = utilisateurs.Select(u => u.ToUtilisateurListDTO()).ToList();

			return Ok(utilisateurDOTS);
		}

		[HttpGet("consumer", Name = "Consumer")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<UtilisateurDTO> Consumer()
		{
			if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int requestUserId))
			{
				Utilisateur utilisateur = _utilisateurService.GetById(requestUserId);
				return Ok(utilisateur.ToUtilisateurDTO());
			}
			return Unauthorized();
		}

		[HttpPut(Name = "Update")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult Update([FromBody] UtilisateurUpdateDTO updateForm)
		{
			if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int requestUserId))
			{
				if (updateForm is null || !ModelState.IsValid)
				{
					return BadRequest();
				}

				Utilisateur updateUser = updateForm.ToUtilisateur();
				updateUser.Id = requestUserId;

				_utilisateurService.Update(updateUser);
				return Ok();
			}
			return Unauthorized();
		}
	}
}
