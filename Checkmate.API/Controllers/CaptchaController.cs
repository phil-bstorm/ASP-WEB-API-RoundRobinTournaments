using Checkmate.API.DTOs;
using Checkmate.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Checkmate.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CaptchaController : ControllerBase
	{
		private readonly IGoogleCaptchaService _googleCaptchaService;

		public CaptchaController(IGoogleCaptchaService googleCaptchaService)
		{
			_googleCaptchaService = googleCaptchaService;
		}

		[HttpPost("verify", Name = "VerifyCaptcha")]
		public async Task<IActionResult> VerifyCaptcha([FromBody] CaptchaVerifyDTO dto)
		{
			if (dto is null || string.IsNullOrEmpty(dto.Token))
			{
				return BadRequest("Token is required.");
			}
			bool isValid = await _googleCaptchaService.VerifyTokenAsync(dto.Token);
			if (isValid)
			{
				return NoContent();
			}
			else
			{
				return BadRequest("Invalid captcha token.");
			}
		}
	}
}
