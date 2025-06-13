namespace RoundRobinTournaments.BLL.CustomExceptions
{
	public class UsernameOrPasswordInvalidException : Exception
	{
		public UsernameOrPasswordInvalidException() : base("Username or password invalid.")
		{
		}

		public UsernameOrPasswordInvalidException(string message) : base(message)
		{
		}
	}
}