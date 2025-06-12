namespace RoundRobinTournaments.Domain.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; } = "";
		public int MinAge { get; set; } = 0;
		public int MaxAge { get; set; } = 100;
	}
}
