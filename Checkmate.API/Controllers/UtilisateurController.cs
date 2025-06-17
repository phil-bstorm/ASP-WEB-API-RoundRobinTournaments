using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Checkmate.API.DTOs;
using Checkmate.API.Mappers;
using Checkmate.BLL.Services.Interfaces;
using Checkmate.Domain.CustomEnums;
using Checkmate.Domain.Models;
using System.Security.Claims;

namespace Checkmate.API.Controllers
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
		[ProducesResponseType(StatusCodes.Status204NoContent)]
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
				return NoContent();
			}
			return Unauthorized();
		}

		[HttpPut("{id}", Name = "Update other user")]
		[Authorize(Roles = nameof(UtilisateurRole.Admin))]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult UpdateUtilisateur([FromRoute] int id, [FromBody] UtilisateurUpdateDTO updateForm)
		{
			if (updateForm is null || !ModelState.IsValid)
			{
				return BadRequest();
			}

			Utilisateur updateUser = updateForm.ToUtilisateur();
			updateUser.Id = id;

			_utilisateurService.Update(updateUser);
			return NoContent();
		}

		[HttpPatch("password", Name = "Update password")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult UpdatePassword([FromBody] UpdatePasswordDTO updatePasswordForm)
		{
			if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int requestUserId))
			{
				if (updatePasswordForm is null || !ModelState.IsValid)
				{
					return BadRequest();
				}

				Utilisateur updateUser = _utilisateurService.GetById(requestUserId);
				updateUser.Password = updatePasswordForm.Password;

				_utilisateurService.Update(updateUser);
				return NoContent();
			}
			return Unauthorized();
		}

		[HttpPatch("password/{id}", Name = "Update password of other user")]
		[Authorize(Roles = nameof(UtilisateurRole.Admin))]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult UpdatePasswordUtilisateur([FromRoute] int id, [FromBody] UpdatePasswordDTO updatePasswordForm)
		{
			if (updatePasswordForm is null || !ModelState.IsValid)
			{
				return BadRequest();
			}

			_utilisateurService.UpdatePassword(id, updatePasswordForm.Password);

			return NoContent();
		}

		[HttpPatch("avatar", Name = "Update avatar")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult> UpdateAvatar([FromForm] UpdateAvatarDTO dto)
		{
			if (int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int requestUserId))
			{
				// check the file
				if (dto == null)
				{
					return BadRequest();
				}

				if (dto.Image == null || dto.Image.Length == 0)
				{
					return BadRequest("No file provided or file is empty.");
				}

				string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
				string extension = Path.GetExtension(dto.Image.FileName).ToLowerInvariant();

				if (!allowedExtensions.Contains(extension))
				{
					return BadRequest("Extension de fichier non autorisée.");
				}

				string fileName = $"avatar_{requestUserId}{extension}";

				// Sauvegarder le chemin de l'avatar dans la base de données
				_utilisateurService.UpdateAvatar(requestUserId, $"/avatars/{fileName}");

				string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "avatars");

				if (!Directory.Exists(folderPath))
				{
					Directory.CreateDirectory(folderPath);
				}

				string filePath = Path.Combine(folderPath, fileName);
				using (FileStream stream = new FileStream(filePath, FileMode.Create))
				{
					await dto.Image.CopyToAsync(stream);
				}

				return NoContent();
			}
			return Unauthorized();
		}

		[HttpPatch("avatar/{id}", Name = "Update avatar of other user")]
		[Authorize(Roles = nameof(UtilisateurRole.Admin))]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult> UpdateAvatar([FromRoute] int id, [FromForm] UpdateAvatarDTO dto)
		{

			// check the file
			if (dto == null)
			{
				return BadRequest();
			}

			if (dto.Image == null || dto.Image.Length == 0)
			{
				return BadRequest("No file provided or file is empty.");
			}

			string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
			string extension = Path.GetExtension(dto.Image.FileName).ToLowerInvariant();

			if (!allowedExtensions.Contains(extension))
			{
				return BadRequest("Extension de fichier non autorisée.");
			}
			
			string fileName = $"avatar_{id}{extension}";

			// Sauvegarder le chemin de l'avatar dans la base de données
			_utilisateurService.UpdateAvatar(id, $"/avatars/{fileName}");

			string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "avatars");

			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}

			string filePath = Path.Combine(folderPath, fileName);
			using (FileStream stream = new FileStream(filePath, FileMode.Create))
			{
				await dto.Image.CopyToAsync(stream);
			}

			return NoContent();
		}
	}
}
