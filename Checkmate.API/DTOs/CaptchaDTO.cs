using System.ComponentModel.DataAnnotations;

namespace Checkmate.API.DTOs
{
	public class CaptchaVerifyDTO
	{
		[Required]
		public required string Token { get; set; }
	}
}
