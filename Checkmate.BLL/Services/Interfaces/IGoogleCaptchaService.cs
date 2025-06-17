namespace Checkmate.BLL.Services.Interfaces
{
	public interface IGoogleCaptchaService
	{
		public Task<bool> VerifyTokenAsync(string token);
	}
}
