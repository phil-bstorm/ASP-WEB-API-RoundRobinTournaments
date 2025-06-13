using Microsoft.AspNetCore.Mvc;
using RoundRobinTournaments.API.DTOs;
using RoundRobinTournaments.API.Mappers;
using RoundRobinTournaments.API.Services;
using RoundRobinTournaments.BLL.Services.Interfaces;
using RoundRobinTournaments.Domain.Models;

namespace RoundRobinTournaments.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IUtilisateurService _utilisateurService;
		private readonly AuthService _authService;

		public AuthController(IUtilisateurService utilisateurService, AuthService authService)
		{
			_utilisateurService = utilisateurService;
			_authService = authService;
		}

		[HttpPost("register", Name = "Register")]
		public ActionResult Register(AuthRegisterDTO registerForm)
		{
			if (registerForm is null || !ModelState.IsValid)
			{
				return BadRequest();
			}

			Utilisateur newUser = registerForm.ToUtilisateur();
			_utilisateurService.Create(newUser);

			return Created();
		}

		[HttpPost("login", Name = "Login")]
		public ActionResult Login(AuthLoginDTO loginForm)
		{
			if (loginForm is null || !ModelState.IsValid)
			{
				return BadRequest();
			}

			Utilisateur utilisateur = _utilisateurService.Login(loginForm.Username, loginForm.Password);

			string token = _authService.GenerateToken(utilisateur);
			return Ok(new TokenResponse { Token = token });
		}
	}
}
