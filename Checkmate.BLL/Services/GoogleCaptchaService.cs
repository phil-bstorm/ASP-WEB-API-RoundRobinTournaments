using Checkmate.BLL.Models;
using Checkmate.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Checkmate.BLL.Services
{
	public class GoogleCaptchaService : IGoogleCaptchaService
	{
		private readonly IConfiguration _config;
		private readonly HttpClient _httpClient;

		public GoogleCaptchaService(IConfiguration config, HttpClient httpClient)
		{
			_config = config;
			_httpClient = httpClient;
		}

		public async Task<bool> VerifyTokenAsync(string token)
		{
			var secret = _config["GoogleCaptcha:SecretKey"];
			var response = await _httpClient.PostAsync(
				$"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={token}",
				null
			);

			var json = await response.Content.ReadAsStringAsync();
			var result = JsonSerializer.Deserialize<GoogleCaptchaResponse>(json);
			return result?.success == true;
		}
	}
}
